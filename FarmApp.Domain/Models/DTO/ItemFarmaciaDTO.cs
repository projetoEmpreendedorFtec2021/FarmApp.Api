namespace FarmApp.Domain.Models.DTO
{
    public class ItemFarmaciaDTO
    {
        public int IdProdutoMarca { get; set; }
        public int IdContaFarmacia { get; set; }
        public int? IdItemFarmacia { get; set; }
        public string CodigoItemFarmacia { get; set; }
        public double Preco { get; set; }
    }
}
