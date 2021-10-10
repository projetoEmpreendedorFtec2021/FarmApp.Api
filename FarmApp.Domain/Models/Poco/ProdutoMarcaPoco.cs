using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models.Poco
{
    public partial class ProdutoMarcaPoco : BaseModel
    {
        public ProdutoMarcaPoco()
        {
            ItemClientes = new HashSet<ItemClientePoco>();
            ItemFarmacia = new HashSet<ItemFarmaciaPoco>();
        }

        public int Idmarca { get; set; }
        public string CodigoProdutoMarca { get; set; }
        public int Idproduto { get; set; }
        public int IdapresentacaoProduto { get; set; }

        public virtual ApresentacaoProdutoPoco ApresentacaoProduto { get; set; }
        public virtual MarcaPoco Marca { get; set; }
        public virtual ProdutoPoco Produto { get; set; }
        public virtual ICollection<ItemClientePoco> ItemClientes { get; set; }
        public virtual ICollection<ItemFarmaciaPoco> ItemFarmacia { get; set; }
    }
}
