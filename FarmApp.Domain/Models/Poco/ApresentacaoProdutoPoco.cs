using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models.Poco
{
    public partial class ApresentacaoProdutoPoco : BaseModel  
    {
        public ApresentacaoProdutoPoco()
        {
            ProdutoMarcas = new HashSet<ProdutoMarcaPoco>();
        }

        public string DescricaoApresentação { get; set; }

        public virtual ICollection<ProdutoMarcaPoco> ProdutoMarcas { get; set; }
    }
}
