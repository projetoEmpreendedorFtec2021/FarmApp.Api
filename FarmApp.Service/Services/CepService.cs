using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models;
using FarmApp.Domain.Models.Poco;
using FarmApp.Service.Builders;
using FarmApp.Service.Validators;
using System.Threading.Tasks;

namespace FarmApp.Service.Services
{
    public class CepService : BaseService<CepPoco>, ICepService
    {
        private readonly ICepRepository _cepRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        public CepService(
            ICepRepository cepRepository, 
            IEnderecoRepository enderecoRepository) : base(cepRepository)
        {
            _cepRepository = cepRepository;
            _enderecoRepository = enderecoRepository;
        }

        public async Task<int> GetIdCepAsync(string numeroCep, int idEndereco)
        {
            var cep = await AddCepIfNotExists(numeroCep, idEndereco);
            return cep.Id;
        }

        public async Task<CepPoco> AddCepIfNotExists(string numeroCep, int idEndereco)
        {
            CepPoco cep = CepBuilder
               .Init(_enderecoRepository)
               .SetNumeroCep(numeroCep)
               .SetIdEndereco(idEndereco)
               .Build();
            var cepExistente = await _cepRepository.CepExistsAsync(cep);
            if (cepExistente is null)
            {
                cepExistente = await AddAsync<CepValidator>(cep);
            }

            return cepExistente;
        }
    }
}
