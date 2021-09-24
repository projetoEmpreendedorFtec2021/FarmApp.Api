using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models.Poco
{
    public partial class ProdutoPoco : BaseModel
    {
        public ProdutoPoco()
        {
            ProdutoMarcas = new HashSet<ProdutoMarcaPoco>();
        }

        public int IdprodutoTipo { get; set; }
        public string DescricaoProduto { get; set; }

        public virtual ProdutoTipoPoco ProdutoTipo { get; set; }
        public virtual ICollection<ProdutoMarcaPoco> ProdutoMarcas { get; set; }
    }
}
