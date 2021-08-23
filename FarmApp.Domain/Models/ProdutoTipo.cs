using System;
using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class ProdutoTipo
    {
        public ProdutoTipo()
        {
            Produtos = new HashSet<Produto>();
        }

        public int Id { get; set; }
        public string DescricaoTipoProduto { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
