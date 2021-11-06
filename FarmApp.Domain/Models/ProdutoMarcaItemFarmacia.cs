using FarmApp.Domain.Models.DTO;

namespace FarmApp.Domain.Models
{
    public class ProdutoMarcaItemFarmacia
    {
        public ProdutoMarcaDTO ProdutoMarca { get; set; }
        public int? IdItemFarmacia { get; set; }
        public double? Preco { get; set; }
        public string CodigoItemFarmacia { get; set; }
    }
}
