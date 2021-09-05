using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models
{
    public partial class Marca : BaseModel
    {
        public Marca()
        {
            ProdutoMarcas = new HashSet<ProdutoMarca>();
        }

        public string NomeMarca { get; set; }

        public virtual ICollection<ProdutoMarca> ProdutoMarcas { get; set; }
    }
}
