using System;
using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class ContaPessoal
    {
        public ContaPessoal()
        {
            Conta = new HashSet<Conta>();
        }

        public int Id { get; set; }
        public sbyte? TemFarmacia { get; set; }
        public string ContaFarmacia { get; set; }
        public string NumeroEndereço { get; set; }
        public string ComplementoEndereco { get; set; }
        public string ContaPessoalcol { get; set; }
        public int IdenderecoContapessoal { get; set; }
        public int IdtipoEndereco { get; set; }

        public virtual EnderecoContapessoal IdNavigation { get; set; }
        public virtual ICollection<Conta> Conta { get; set; }
    }
}
