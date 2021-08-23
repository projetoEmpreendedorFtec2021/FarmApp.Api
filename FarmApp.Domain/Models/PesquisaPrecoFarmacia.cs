using System;
using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class PesquisaPrecoFarmacia
    {
        public int Id { get; set; }
        public int Idpesquisa { get; set; }
        public int IditemFarmacia { get; set; }

        public virtual ItemFarmacia IditemFarmaciaNavigation { get; set; }
        public virtual PesquisaPreco IdpesquisaNavigation { get; set; }
    }
}
