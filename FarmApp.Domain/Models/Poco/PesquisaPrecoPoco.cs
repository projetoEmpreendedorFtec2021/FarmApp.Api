using System;
using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models.Poco
{
    public partial class PesquisaPrecoPoco : BaseModel
    {
        public PesquisaPrecoPoco()
        {
            PesquisaPrecoFarmacia = new HashSet<PesquisaPrecoFarmaciaPoco>();
        }

        public int Idcliente { get; set; }
        public int IditemCliente { get; set; }
        public DateTime? DataHora { get; set; }

        public virtual ClientePoco IdclienteNavigation { get; set; }
        public virtual ItemClientePoco IditemClienteNavigation { get; set; }
        public virtual ICollection<PesquisaPrecoFarmaciaPoco> PesquisaPrecoFarmacia { get; set; }
    }
}
