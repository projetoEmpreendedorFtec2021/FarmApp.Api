using FarmApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmApp.Service.Builders
{
    public class ContaBuilder
    {
        private readonly Conta _conta = new Conta();

        private ContaBuilder()
        {

        }

        public static ContaBuilder Init()
        {
            return new ContaBuilder();
        }

        public Conta Build() => _conta;

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
