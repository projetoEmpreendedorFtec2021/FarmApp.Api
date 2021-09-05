using FarmApp.Domain.Models;
using System;

namespace FarmApp.Service.Builders
{
    public class BairroBuilder
    {
        private readonly Bairro _bairro = new Bairro();

        private BairroBuilder() { }

        public static BairroBuilder Init()
        {
            return new BairroBuilder();
        }

        public Bairro Build() => _bairro;

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
