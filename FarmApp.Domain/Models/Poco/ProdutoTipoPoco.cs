using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models.Poco
{
    public partial class ProdutoTipoPoco : BaseModel
    {
        public ProdutoTipoPoco()
        {
            Produtos = new HashSet<ProdutoPoco>();
        }

        public string DescricaoTipoProduto { get; set; }

        public virtual ICollection<ProdutoPoco> Produtos { get; set; }
    }
}
