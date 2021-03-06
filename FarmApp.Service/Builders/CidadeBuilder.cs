using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Models.Poco;
using System;

namespace FarmApp.Service.Builders
{
    public class CidadeBuilder
    {
        private readonly CidadePoco _cidade = new CidadePoco();
        private readonly IUfRepository _ufRepository;
        
        private CidadeBuilder(IUfRepository ufRepository)
        {
            _ufRepository = ufRepository;
        }

        public static CidadeBuilder Init(IUfRepository ufRepository)
        {
            return new CidadeBuilder(ufRepository);
        }

        public CidadePoco Build() => _cidade;

        public CidadeBuilder SetNomeCidade(string nomeCidade)
        {
            if (string.IsNullOrEmpty(nomeCidade))
            {
                throw new ArgumentNullException($"Parâmetro {nameof(nomeCidade)} está nulo");
            }

            _cidade.NomeCidade = nomeCidade;
            return this;
        }

        public CidadeBuilder SetIdUf(int idUf)
        {
            if (idUf == 0)
            {
                throw new ArgumentNullException($"Parâmetro {nameof(idUf)} não pode ser zero");
            }

            _cidade.Iduf = idUf;
            return this;
        }
    }
}
