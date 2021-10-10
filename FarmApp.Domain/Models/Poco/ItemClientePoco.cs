using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models.Poco
{
    public partial class ItemClientePoco : BaseModel
    {
        public ItemClientePoco()
        {
            PesquisaPrecos = new HashSet<PesquisaPrecoPoco>();
        }

        public int IdCliente { get; set; }
        public int IdProdutoMarca { get; set; }

        public virtual ClientePoco Cliente { get; set; }
        public virtual ProdutoMarcaPoco ProdutoMarca { get; set; }
        public virtual ICollection<PesquisaPrecoPoco> PesquisaPrecos { get; set; }
    }
}
