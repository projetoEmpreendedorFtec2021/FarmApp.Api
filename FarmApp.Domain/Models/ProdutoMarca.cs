namespace FarmApp.Domain.Models
{
    public class ProdutoMarca : BaseModel
    {
        public string CodigoProdutoMarca { get; set; }
        public virtual ApresentacaoProduto ApresentacaoProduto { get; set; }
        public virtual Marca Marca { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
