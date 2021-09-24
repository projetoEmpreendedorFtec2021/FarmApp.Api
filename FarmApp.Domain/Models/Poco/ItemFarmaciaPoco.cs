using System.Collections.Generic;

#nullable disable

namespace FarmApp.Domain.Models.Poco
{
    public partial class ItemFarmaciaPoco : BaseModel
    {
        public ItemFarmaciaPoco()
        {
            PesquisaPrecoFarmacia = new HashSet<PesquisaPrecoFarmacia>();
        }

        public int IdprodutoMarca { get; set; }
        public int IdcontaFarmacia { get; set; }
        public string CodigoItemFarmacia { get; set; }
        public double? Preco { get; set; }

        public virtual ContaFarmaciaPoco IdcontaFarmaciaNavigation { get; set; }
        public virtual ProdutoMarcaPoco IdprodutoMarcaNavigation { get; set; }
        public virtual ICollection<PesquisaPrecoFarmacia> PesquisaPrecoFarmacia { get; set; }
    }
}
