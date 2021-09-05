using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models;
using FarmApp.Service.Builders;
using FarmApp.Service.Validators;
using System.Threading.Tasks;

namespace FarmApp.Service.Services
{
    public class EnderecoContaPessoalService : BaseService<EnderecoContapessoal>, IEnderecoContaPessoalService
    {
        private readonly IEnderecoContaPessoalRepository _enderecoContaPessoalRepository;
        private readonly ITipoEnderecoRepository _tipoEnderecoRepository;
        private readonly ICepRepository _cepRepository;
        private readonly IContaPessoalRepository _contaPessoalRepository;

        public EnderecoContaPessoalService(
            IEnderecoContaPessoalRepository enderecoContaPessoalRepository,
            ITipoEnderecoRepository tipoEnderecoRepository,
            ICepRepository cepRepository,
            IContaPessoalRepository contaPessoalRepository) : base(enderecoContaPessoalRepository)
        {
            _enderecoContaPessoalRepository = enderecoContaPessoalRepository;
            _tipoEnderecoRepository = tipoEnderecoRepository;
            _cepRepository = cepRepository;
            _contaPessoalRepository = contaPessoalRepository;
        }

        public async Task<int> GetIdEnderecoContaPessoalAsync(int idTipoEndereco, int idCep, string numero, string complemento, int idContaPessoal)
        {
            EnderecoContapessoal enderecoContapessoal = EnderecoContaPessoalBuilder
                .Init(_tipoEnderecoRepository, _cepRepository, _contaPessoalRepository)
                .SetIdTipoEndereco(idTipoEndereco)
                .SetIdCep(idCep)
                .SetNumero(numero)
                .SetComplemento(complemento)
                .SetIdContaPessoal(idContaPessoal)
                .Build();

            var enderecoContaPessoalExistente = await _enderecoContaPessoalRepository.EnderecoContaPessoalExists(
                idTipoEndereco, 
                idCep, 
                numero, 
                complemento,
                idContaPessoal);

            if(enderecoContaPessoalExistente is null)
            {
                enderecoContaPessoalExistente = await AddAsync<EnderecoContaPessoalValidator>(enderecoContapessoal);
            }

            return enderecoContaPessoalExistente.Id;
        }
    }
}
