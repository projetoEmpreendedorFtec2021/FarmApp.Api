using System;

#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class Consentimento : BaseModel
    {
        public string Finalidade { get; set; }
        public string Situacao { get; set; }
        public DateTime? Data { get; set; }
        public int Idcliente { get; set; }

        public virtual Cliente IdclienteNavigation { get; set; }
    }
}
