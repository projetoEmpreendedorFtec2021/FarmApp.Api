using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class Midia : BaseModel
    {
        public Midia()
        {
            MensagemSistemas = new HashSet<MensagemSistema>();
        }

        public string Descricao { get; set; }

        public virtual ICollection<MensagemSistema> MensagemSistemas { get; set; }
    }
}
