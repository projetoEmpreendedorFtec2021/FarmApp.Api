using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Models.Poco;
using System;

namespace FarmApp.Service.Builders
{
    public class ConsentimentoBuilder
    {
        private readonly ConsentimentoPoco _consentimento = new ConsentimentoPoco();
        private readonly IClienteRepository _clienteRepository;

        private ConsentimentoBuilder(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public static ConsentimentoBuilder Init(IClienteRepository clienteRepository)
        {
            return new ConsentimentoBuilder(clienteRepository);
        }

        public ConsentimentoPoco Build() => _consentimento;

        public ConsentimentoBuilder SetFinalidade(string finalidade)
        {
            if (string.IsNullOrEmpty(finalidade))
            {
                throw new ArgumentNullException("A finalidade está nula");
            }

            _consentimento.Finalidade = finalidade;
            return this;
        }

        public ConsentimentoBuilder SetSituacao(string situacao)
        {
            if(string.IsNullOrEmpty(situacao))
            {
                throw new ArgumentNullException("A situação está nula");
            }

            _consentimento.Situacao = situacao;
            return this;
        }

        public ConsentimentoBuilder SetData(DateTime data)
        {
            if(data == DateTime.MinValue)
            {
                throw new ArgumentNullException("A data não é válida");
            }
            _consentimento.Data = data;
            return this;
        }

        public ConsentimentoBuilder SetIdCliente(int idCliente)
        {
            if(idCliente == 0)
            {
                throw new ArgumentNullException("O IdCliente não pode ser zero");
            }

            var clienteExiste = _clienteRepository.GetByIdAsync(idCliente).Result;
            if(clienteExiste is null)
            {
                throw new Exception("IdCliente não encontrado");
            }
            _consentimento.Idcliente = idCliente;
            return this;
        }
    }
}
