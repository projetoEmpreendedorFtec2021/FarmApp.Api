using System;

namespace FarmApp.Domain.Models.DTO
{
    public class ClienteDTO : ContaDTO
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string RepeteSenha { get; set; }
        public string CPF { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Complemento { get; set; }
        public string SituacaoConsentimento { get; set; }
    }
}
