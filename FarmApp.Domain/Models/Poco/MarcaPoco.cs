using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models.Poco
{
    public partial class MarcaPoco : BaseModel
    {
        public MarcaPoco()
        {
            ProdutoMarcas = new HashSet<ProdutoMarcaPoco>();
        }

        public string NomeMarca { get; set; }

        public virtual ICollection<ProdutoMarcaPoco> ProdutoMarcas { get; set; }
    }
}
