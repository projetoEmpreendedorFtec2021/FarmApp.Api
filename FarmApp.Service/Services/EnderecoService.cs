using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models;
using FarmApp.Domain.Models.DTO;
using FarmApp.Service.Builders;
using FarmApp.Service.Validators;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using ViaCep;

namespace FarmApp.Service.Services
{
    public class EnderecoService : BaseService<Endereco>, IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly ICidadeRepository _cidadeRepository;
        private readonly IBairroRepository _bairroRepository;

        public EnderecoService(
            IEnderecoRepository enderecoRepository,
            ICidadeRepository cidadeRepository,
            IBairroRepository bairroRepository) : base(enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
            _cidadeRepository = cidadeRepository;
            _bairroRepository = bairroRepository;
        }

        public async Task<EnderecoDTO> GetEnderecoFromCEPAsync(string CEP)
        {
            var cancellationToken = new CancellationToken();
            CEP = CEP
                .Trim()
                .Replace(".", string.Empty)
                .Replace("-", string.Empty);

            if (CEP.Length == 8 && Regex.IsMatch(CEP, @"^\d+$"))
            { 
                var viaCepClient = await new ViaCepClient().SearchAsync(CEP, cancellationToken);
                if (viaCepClient.StateInitials != null)
                {
                    return new EnderecoDTO()
                    {
                        Uf = viaCepClient.StateInitials,
                        Cidade = viaCepClient.City,
                        Bairro = viaCepClient.Neighborhood,
                        Logradouro = viaCepClient.Street
                    };
                }
                return null;
            }
            return null;
        }

        public async Task<int> GetIdEnderecoAsync(string nomeEndereco, int idCidade, int idBairro)
        {
            var endereco = EnderecoBuilder
                .Init(_cidadeRepository, _bairroRepository)
                .SetNomeEndereco(nomeEndereco)
                .SetIdCidade(idCidade)
                .SetIdBairro(idBairro)
                .Build();

            var enderecoExistente = await _enderecoRepository.EnderecoExistsAsync(endereco);
        
            if (enderecoExistente is null)
            {
                enderecoExistente = await AddAsync<EnderecoValidator>(endereco);
            }
            
            return enderecoExistente.Id;
        }
       
    }
}
