using System;
using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class Consentimento
    {
        public Consentimento()
        {
            ClienteConsentimentos = new HashSet<ClienteConsentimento>();
        }

        public int Id { get; set; }
        public string Finalidade { get; set; }
        public string Situacao { get; set; }
        public DateTime? Data { get; set; }

        public virtual ICollection<ClienteConsentimento> ClienteConsentimentos { get; set; }
    }
}
