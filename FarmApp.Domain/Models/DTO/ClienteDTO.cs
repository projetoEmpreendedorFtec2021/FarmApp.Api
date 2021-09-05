using System;
using System.Collections.Generic;
using System.Text;

namespace FarmApp.Domain.Models.DTO
{
    public class ClienteDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string RepeteSenha { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Celular { get; set; }
        public string CEP { get; set; }
        public string Uf { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string SituacaoConsentimento { get; set; }
    }
}
