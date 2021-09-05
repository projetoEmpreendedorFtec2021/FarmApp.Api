using System;
using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class PesquisaPreco : BaseModel
    {
        public PesquisaPreco()
        {
            PesquisaPrecoFarmacia = new HashSet<PesquisaPrecoFarmacia>();
        }

        public int Idcliente { get; set; }
        public int IditemCliente { get; set; }
        public DateTime? DataHora { get; set; }

        public virtual Cliente IdclienteNavigation { get; set; }
        public virtual ItemCliente IditemClienteNavigation { get; set; }
        public virtual ICollection<PesquisaPrecoFarmacia> PesquisaPrecoFarmacia { get; set; }
    }
}
