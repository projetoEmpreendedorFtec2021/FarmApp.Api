using FarmApp.Domain.Models.Poco;
using System;

namespace FarmApp.Service.Builders
{
    public class ContaBuilder
    {
        private readonly ContaPoco _conta = new ContaPoco();

        private ContaBuilder()
        {

        }

        public static ContaBuilder Init()
        {
            return new ContaBuilder();
        }

        public ContaPoco Build() => _conta;

        public ContaBuilder SetDataCriacao(DateTime dataCriacao)
        {
            _conta.DataCriacao = dataCriacao.ToString();
            return this;
        }
        
        public ContaBuilder SetIdContaPessoal(int idContaPessoal)
        {
            if(idContaPessoal == 0)
            {
                throw new ArgumentNullException($"Parâmetro {nameof(idContaPessoal)} não pode ser zero");
            }
            
            _conta.IdcontaPessoal = idContaPessoal;
            
            return this;
        }
    }
}
