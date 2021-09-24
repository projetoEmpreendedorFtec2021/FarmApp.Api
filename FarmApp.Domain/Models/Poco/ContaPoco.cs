using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models.Poco
{
    public partial class ContaPoco : BaseModel
    {
        public ContaPoco()
        {
            Clientes = new HashSet<ClientePoco>();
            ContaMensagemSistemas = new HashSet<ContaMensagemSistemaPoco>();
        }

        public string DataCriacao { get; set; }
        public string DataEncerramento { get; set; }
        public int IdcontaPessoal { get; set; }
        public int? IdcontaFarmacia { get; set; }

        public virtual ContaFarmaciaPoco IdcontaFarmaciaNavigation { get; set; }
        public virtual ContaPessoalPoco IdcontaPessoalNavigation { get; set; }
        public virtual ICollection<ClientePoco> Clientes { get; set; }
        public virtual ICollection<ContaMensagemSistemaPoco> ContaMensagemSistemas { get; set; }
    }
}
