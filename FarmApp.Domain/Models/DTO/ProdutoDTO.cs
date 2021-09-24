namespace FarmApp.Domain.Models.DTO
{
    public class ProdutoDTO : BaseModelPaginated
    {
        public int IdTipoProduto { get; set; }
        public string Busca { get; set; }
    }
}
