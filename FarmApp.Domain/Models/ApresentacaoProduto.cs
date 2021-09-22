using System;
using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class ApresentacaoProduto : BaseModel

    {
        public ApresentacaoProduto()
        {
            ProdutoMarcas = new HashSet<ProdutoMarca>();
        }

        public string DescricaoApresentação { get; set; }

        public virtual ICollection<ProdutoMarca> ProdutoMarcas { get; set; }
    }
}
