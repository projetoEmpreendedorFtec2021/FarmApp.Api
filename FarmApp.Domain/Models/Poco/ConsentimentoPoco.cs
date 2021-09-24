using FarmApp.Domain.Models.Poco;
using System;

#nullable disable

namespace FarmApp.Domain.Models.Poco
{
    public partial class ConsentimentoPoco : BaseModel
    {
        public string Finalidade { get; set; }
        public string Situacao { get; set; }
        public DateTime? Data { get; set; }
        public int Idcliente { get; set; }

        public virtual ClientePoco IdclienteNavigation { get; set; }
    }
}
