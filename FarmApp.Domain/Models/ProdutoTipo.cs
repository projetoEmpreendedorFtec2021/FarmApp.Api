using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class ProdutoTipo : BaseModel
    {
        public ProdutoTipo()
        {
            Produtos = new HashSet<Produto>();
        }

        public string DescricaoTipoProduto { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
