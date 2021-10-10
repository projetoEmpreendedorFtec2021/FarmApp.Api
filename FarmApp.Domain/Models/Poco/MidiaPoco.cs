using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models.Poco
{
    public partial class MidiaPoco : BaseModel
    {
        public MidiaPoco()
        {
            MensagemSistemas = new HashSet<MensagemSistemaPoco>();
        }

        public string Descricao { get; set; }

        public virtual ICollection<MensagemSistemaPoco> MensagemSistemas { get; set; }
    }
}
