using FarmApp.Domain.Models;

namespace FarmApp.Service.Builders
{
    public class UfBuilder
    {
        private readonly Uf _uf = new Uf();

        private UfBuilder()
        {

        }

        public static UfBuilder Init()
        {
            return new UfBuilder();
        }

        public Uf Build() => _uf;

        public UfBuilder SetNomeUf(string nomeUf)
        {
            if (!string.IsNullOrEmpty(nomeUf))
            {
                _uf.NomeUf = nomeUf;
            }
            return this;
        }
    }
}
