using System;
using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class ContaFarmacia
    {
        public ContaFarmacia()
        {
            Conta = new HashSet<Conta>();
            ItemFarmacia = new HashSet<ItemFarmacia>();
        }

        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string NomeFantasia { get; set; }
        public string Alvara { get; set; }
        public string Endereco { get; set; }
        public string Site { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public int Idcep { get; set; }
        public string NumeroEndereçofarmacia { get; set; }
        public string LatilongFarmacia { get; set; }

        public virtual Cep IdcepNavigation { get; set; }
        public virtual ICollection<Conta> Conta { get; set; }
        public virtual ICollection<ItemFarmacia> ItemFarmacia { get; set; }
    }
}
