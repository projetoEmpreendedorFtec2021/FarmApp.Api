using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class Conta : BaseModel
    {
        public Conta()
        {
            Clientes = new HashSet<Cliente>();
            ContaMensagemSistemas = new HashSet<ContaMensagemSistema>();
        }

        public string DataCriacao { get; set; }
        public string DataEncerramento { get; set; }
        public int IdcontaPessoal { get; set; }
        public int? IdcontaFarmacia { get; set; }

        public virtual ContaFarmacia IdcontaFarmaciaNavigation { get; set; }
        public virtual ContaPessoal IdcontaPessoalNavigation { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<ContaMensagemSistema> ContaMensagemSistemas { get; set; }
    }
}
