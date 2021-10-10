using System;
using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models.Poco
{
    public partial class MotivoPoco
    {
        public MotivoPoco()
        {
            MensagemSistemas = new HashSet<MensagemSistemaPoco>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<MensagemSistemaPoco> MensagemSistemas { get; set; }
    }
}
