using System;
using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class ItemFarmacia
    {
        public ItemFarmacia()
        {
            PesquisaPrecoFarmacia = new HashSet<PesquisaPrecoFarmacia>();
        }

        public int Id { get; set; }
        public int IdprodutoMarca { get; set; }
        public int IdcontaFarmacia { get; set; }
        public string CodigoItemFarmacia { get; set; }
        public double? Preco { get; set; }

        public virtual ContaFarmacia IdcontaFarmaciaNavigation { get; set; }
        public virtual ProdutoMarca IdprodutoMarcaNavigation { get; set; }
        public virtual ICollection<PesquisaPrecoFarmacia> PesquisaPrecoFarmacia { get; set; }
    }
}
