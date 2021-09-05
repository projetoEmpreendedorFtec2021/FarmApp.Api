using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models;
using System.Linq;

namespace FarmApp.Service.Builders
{
    public class CepBuilder
    {
        private readonly Cep _cep = new Cep();
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

        public Cep Build() => _cep;

        public CepBuilder SetNumeroCep(string numeroCep)
        { 
            if(!string.IsNullOrEmpty(numeroCep) 
                && numeroCep.Trim().Replace("-", string.Empty).Length == 8)
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
