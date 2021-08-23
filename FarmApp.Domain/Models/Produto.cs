using System;
using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class Produto
    {
        public Produto()
        {
            ProdutoMarcas = new HashSet<ProdutoMarca>();
        }

        public int Id { get; set; }
        public int IdprodutoTipo { get; set; }
        public string DescricaoProduto { get; set; }

        public virtual ProdutoTipo IdprodutoTipoNavigation { get; set; }
        public virtual ICollection<ProdutoMarca> ProdutoMarcas { get; set; }
    }
}
