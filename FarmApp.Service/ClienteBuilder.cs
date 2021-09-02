using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FarmApp.Service
{
    public class ClienteBuilder
    {
        private Cliente _cliente = new Cliente();
        private readonly IClienteService _clienteService;

        private ClienteBuilder(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public static ClienteBuilder Init(IClienteService clienteService)
        {
            return new ClienteBuilder(clienteService);
        }

        public Cliente Build() => _cliente;

        public ClienteBuilder SetNome(string nome)
        {
            if (!string.IsNullOrEmpty(nome))
            {
                _cliente.Nome = nome;
            }
            return this;
        }

        public ClienteBuilder SetLogin(string email)
        {
            var emailCadastrado = _clienteService.IsEmailCadastrado(email);
            if (!string.IsNullOrEmpty(email) && !emailCadastrado)
            {
                _cliente.Login = email;
            }
            return this;
        }

        public ClienteBuilder SetSenha(string senha, string repeteSenha)
        {
            if(senha == repeteSenha)
            {
                _cliente.Senha = senha;
            }
            return this;
        }
        public ClienteBuilder SetCPF(string CPF)
        {
            if (!string.IsNullOrEmpty(CPF))
            {
                _cliente.Cpf = CPF;
            }
            return this;
        }
    }
}
