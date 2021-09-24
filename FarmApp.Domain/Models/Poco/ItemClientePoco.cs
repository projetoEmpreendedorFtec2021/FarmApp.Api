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

        public int Idcliente { get; set; }
        public int IdprodutoMarca { get; set; }

        public virtual ClientePoco IdclienteNavigation { get; set; }
        public virtual ProdutoMarcaPoco IdprodutoMarcaNavigation { get; set; }
        public virtual ICollection<PesquisaPrecoPoco> PesquisaPrecos { get; set; }
    }
}
