using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Models.Poco;
using System;

namespace FarmApp.Service.Builders
{
    public class EnderecoContaPessoalBuilder
    {
        private readonly EnderecoContapessoalPoco _endereco = new EnderecoContapessoalPoco();
        private readonly ITipoEnderecoRepository _tipoEnderecoRepository;
        private readonly ICepRepository _cepRepository;
        private readonly IContaPessoalRepository _contaPessoalRepository;

        private EnderecoContaPessoalBuilder(
            ITipoEnderecoRepository tipoEnderecoRepository,
            ICepRepository cepRepository,
            IContaPessoalRepository contaPessoalRepository)
        {
            _tipoEnderecoRepository = tipoEnderecoRepository;
            _cepRepository = cepRepository;
            _contaPessoalRepository = contaPessoalRepository;
        }

        public static EnderecoContaPessoalBuilder Init(
            ITipoEnderecoRepository tipoEnderecoRepository,
            ICepRepository cepRepository,
            IContaPessoalRepository contaPessoalRepository)
        {
            return new EnderecoContaPessoalBuilder(tipoEnderecoRepository, cepRepository, contaPessoalRepository);
        }

        public EnderecoContapessoalPoco Build() => _endereco;

        public EnderecoContaPessoalBuilder SetIdTipoEndereco(int idTipoEndereco)
        {
            if(idTipoEndereco == 0 || _tipoEnderecoRepository.GetByIdAsync(idTipoEndereco).Result is null)
            {
                throw new ArgumentNullException($"Parâmetro {nameof(idTipoEndereco)} não encontrado");
            }

            _endereco.IdtipoEndereco = idTipoEndereco;

            return this;
        }

        public EnderecoContaPessoalBuilder SetIdCep(int idCep)
        {
            if (idCep == 0 || _cepRepository.GetByIdAsync(idCep).Result is null)
            {
                throw new ArgumentNullException($"Parâmetro {nameof(idCep)} não encontrado");
            }
            _endereco.Idcep = idCep;

            return this;
        }

        public EnderecoContaPessoalBuilder SetNumero(string numero)
        {
            _endereco.Numero = numero;

            return this;
        }

        public EnderecoContaPessoalBuilder SetComplemento(string complemento)
        {
            _endereco.Complemento = complemento;

            return this;
        }

        public EnderecoContaPessoalBuilder SetIdContaPessoal(int idContaPessoal)
        {
            if (idContaPessoal == 0 || _contaPessoalRepository.GetByIdAsync(idContaPessoal).Result is null)
            {
                throw new ArgumentNullException($"Parâmetro {nameof(idContaPessoal)} não encontrado");
            }
            _endereco.IdcontaPessoal = idContaPessoal;

            return this;
        }
    }
}
