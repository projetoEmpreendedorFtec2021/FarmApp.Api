using System;
using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class MensagemSistema : BaseModel
    {
        public MensagemSistema()
        {
            ContaMensagemSistemas = new HashSet<ContaMensagemSistema>();
        }

        public int? Idmotivo { get; set; }
        public string Mensagdescricao { get; set; }
        public DateTime? Datahora { get; set; }
        public int Idmidia { get; set; }

        public virtual Midia IdmidiaNavigation { get; set; }
        public virtual Motivo IdmotivoNavigation { get; set; }
        public virtual ICollection<ContaMensagemSistema> ContaMensagemSistemas { get; set; }
    }
}
