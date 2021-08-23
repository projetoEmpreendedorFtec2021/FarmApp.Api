using System;
using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class ProdutoMarca
    {
        public ProdutoMarca()
        {
            ItemClientes = new HashSet<ItemCliente>();
            ItemFarmacia = new HashSet<ItemFarmacia>();
        }

        public int Id { get; set; }
        public int Idmarca { get; set; }
        public string CodigoProdutoMarca { get; set; }
        public int Idproduto { get; set; }
        public int IdapresentacaoProduto { get; set; }

        public virtual ApresentacaoProduto IdapresentacaoProdutoNavigation { get; set; }
        public virtual Marca IdmarcaNavigation { get; set; }
        public virtual Produto IdprodutoNavigation { get; set; }
        public virtual ICollection<ItemCliente> ItemClientes { get; set; }
        public virtual ICollection<ItemFarmacia> ItemFarmacia { get; set; }
    }
}
