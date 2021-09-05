using System;
using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class Motivo
    {
        public Motivo()
        {
            MensagemSistemas = new HashSet<MensagemSistema>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<MensagemSistema> MensagemSistemas { get; set; }
    }
}
