using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Models.Poco;
using System.Linq;

namespace FarmApp.Service.Builders
{
    public class CepBuilder
    {
        private readonly CepPoco _cep = new CepPoco();
        private readonly IEnderecoRepository _enderecoRepository;
        private CepBuilder(
            IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public static CepBuilder Init(
            IEnderecoRepository enderecoRepository)
        {
            return new CepBuilder(enderecoRepository);
        }

        public CepPoco Build() => _cep;

        public CepBuilder SetNumeroCep(string numeroCep)
        {
            numeroCep = numeroCep.Trim().Replace("-", string.Empty);
            if(!string.IsNullOrEmpty(numeroCep) 
                && numeroCep.Length == 8)
            {
                _cep.NumeroCep = numeroCep;
            }
            return this;
        }

        public CepBuilder SetIdEndereco(int idEndereco)
        {
            if(idEndereco != 0 
                && _enderecoRepository.GetAllAsync().Result.Any(x => x.Id == idEndereco))
            {
                _cep.Idendereco = idEndereco;
            }
            return this;
        }
    }
}
