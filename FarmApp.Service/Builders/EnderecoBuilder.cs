using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Models;
using System.Linq;

namespace FarmApp.Service.Builders
{
    public class EnderecoBuilder
    {
        private Endereco _endereco = new Endereco();
        private readonly ICidadeRepository _cidadeRepository;
        private readonly IBairroRepository _bairroRepository;

        private EnderecoBuilder(
            ICidadeRepository cidadeRepository,
            IBairroRepository bairroRepository)
        {
            _cidadeRepository = cidadeRepository;
            _bairroRepository = bairroRepository;
        }

        public static EnderecoBuilder Init(
            ICidadeRepository cidadeRepository,
            IBairroRepository bairroRepository)
        {
            return new EnderecoBuilder(cidadeRepository, bairroRepository);
        }

        public Endereco Build() => _endereco;
        public EnderecoBuilder SetNomeEndereco(string endereco)
        {
            if (!string.IsNullOrEmpty(endereco))
            {
                _endereco.NomeEndereco = endereco;
            }
            return this;
        }
        public EnderecoBuilder SetIdCidade(int idCidade)
        {
            var cidades = _cidadeRepository.GetAllAsync().Result;
            if(idCidade != 0 && cidades.Any(x => x.Id == idCidade))
            {
                _endereco.Idcidade = idCidade;
            }
            return this;
        }

        public EnderecoBuilder SetIdBairro(int idBairro)
        {
            var bairros = _bairroRepository.GetAllAsync().Result;
            if (idBairro != 0 && bairros.Any(x => x.Id == idBairro))
            {
                _endereco.Idbairro = idBairro;
            }
            return this;
        }
    }
}

