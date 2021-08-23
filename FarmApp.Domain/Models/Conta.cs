using System;
using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class Conta
    {
        public Conta()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int Id { get; set; }
        public string DataCriacao { get; set; }
        public string DataEncerramento { get; set; }
        public int IdcontaPessoal { get; set; }
        public int IdcontaFarmacia { get; set; }
        public int IdmensagemSistema { get; set; }

        public virtual ContaFarmacia IdcontaFarmaciaNavigation { get; set; }
        public virtual ContaPessoal IdcontaPessoalNavigation { get; set; }
        public virtual MensagemSistema IdmensagemSistemaNavigation { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
