using System;
using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models.Poco
{
    public partial class MensagemSistemaPoco : BaseModel
    {
        public MensagemSistemaPoco()
        {
            ContaMensagemSistemas = new HashSet<ContaMensagemSistemaPoco>();
        }

        public int? Idmotivo { get; set; }
        public string Mensagdescricao { get; set; }
        public DateTime? Datahora { get; set; }
        public int Idmidia { get; set; }

        public virtual MidiaPoco IdmidiaNavigation { get; set; }
        public virtual MotivoPoco IdmotivoNavigation { get; set; }
        public virtual ICollection<ContaMensagemSistemaPoco> ContaMensagemSistemas { get; set; }
    }
}
