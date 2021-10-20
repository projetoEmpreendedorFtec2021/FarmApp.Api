using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models.Poco
{
    public partial class MotivoPoco : BaseModel
    {
        public MotivoPoco()
        {
            MensagemSistemas = new HashSet<MensagemSistemaPoco>();
        }

        public string Descricao { get; set; }

        public virtual ICollection<MensagemSistemaPoco> MensagemSistemas { get; set; }
    }
}
