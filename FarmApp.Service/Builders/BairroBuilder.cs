using FarmApp.Domain.Models.Poco;
using System;

namespace FarmApp.Service.Builders
{
    public class BairroBuilder
    {
        private readonly BairroPoco _bairro = new BairroPoco();

        private BairroBuilder() { }

        public static BairroBuilder Init()
        {
            return new BairroBuilder();
        }

        public BairroPoco Build() => _bairro;

        public BairroBuilder SetNomeBairro(string nomeBairro)
        {
            if (string.IsNullOrEmpty(nomeBairro))
            {
                throw new ArgumentNullException($"Parâmetro : {nameof(nomeBairro)} nulo");
            }

            _bairro.NomeBairro = nomeBairro;
            return this;
        }
    }
}
