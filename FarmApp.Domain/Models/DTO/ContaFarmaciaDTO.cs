using System;
using System.Collections.Generic;
using System.Text;

namespace FarmApp.Domain.Models.DTO
{
    public class ContaFarmaciaDTO : ContaDTO
    {
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string NomeFantasia { get; set; }
        public string Alvara { get; set; }
        public string Site { get; set; }
        public string Telefone { get; set; }
        public int IdCliente { get; set; }
    }
}
