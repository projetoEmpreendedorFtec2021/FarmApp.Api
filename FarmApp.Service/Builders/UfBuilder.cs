using FarmApp.Domain.Models.Poco;

namespace FarmApp.Service.Builders
{
    public class UfBuilder
    {
        private readonly UfPoco _uf = new UfPoco();

        private UfBuilder()
        {

        }

        public static UfBuilder Init()
        {
            return new UfBuilder();
        }

        public UfPoco Build() => _uf;

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
