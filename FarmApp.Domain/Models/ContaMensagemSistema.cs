using System;
using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class ContaMensagemSistema
    {
        public int Id { get; set; }
        public int Idconta { get; set; }
        public int IdmensagemSistema { get; set; }

        public virtual Conta IdcontaNavigation { get; set; }
        public virtual MensagemSistema IdmensagemSistemaNavigation { get; set; }
    }
}
