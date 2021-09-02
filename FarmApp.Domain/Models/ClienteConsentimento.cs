using System;
using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class ClienteConsentimento
    {
        public int Id { get; set; }
        public int Idcliente { get; set; }
        public int Idconsentimento { get; set; }
        public DateTime? Data { get; set; }

        public virtual Cliente IdclienteNavigation { get; set; }
        public virtual Consentimento IdconsentimentoNavigation { get; set; }
    }
}
