using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Models;
using System;
using System.Text.RegularExpressions;

namespace FarmApp.Service.Builders
{
    public class ClienteBuilder
    {
        private Cliente _cliente = new Cliente();
        private readonly IClienteRepository _clienteRepository;

        private ClienteBuilder(
            IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public static ClienteBuilder Init(IClienteRepository clienteRepository)
        {
            return new ClienteBuilder(clienteRepository);
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
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("E-mail nulo");
            }

            Cliente clienteExistente = _clienteRepository.GetClientePorEmail(email);

            if (clienteExistente != null)
            {
                throw new Exception("E-mail já cadastrado");
            }

            _cliente.Login = email;
            return this;
        }

        public ClienteBuilder SetSenha(string senha, string repeteSenha)
        {
            if (senha == repeteSenha)
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

        public ClienteBuilder SetCelular(string celular)
        {
            var padrao = @"^\(?(?:[14689][1-9]|2[12478]|3[1234578]|5[1345]|7[134579])\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$";
            if (Regex.IsMatch(celular, padrao))
            {
                _cliente.Celular = celular;
            }
            return this;
        }

        public ClienteBuilder SetDataNascimento(DateTime? dataNascimento)
        {
            if (dataNascimento != null)
            {
                _cliente.DataNascimento = dataNascimento;
            }
            return this;
        }

        public ClienteBuilder SetIdConta(int idConta)
        {
            if (idConta == 0)
            {
                throw new ArgumentNullException($"Parâmetro {nameof(idConta)} não pode ser zero");
            }
            _cliente.Idconta = idConta;
            return this;
        }
    }
}
