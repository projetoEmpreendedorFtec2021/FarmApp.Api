namespace FarmApp.Domain.Models
{
    public class Produto : BaseModel
    {
        public string DescricaoProduto { get; set; }
        public ProdutoTipo ProdutoTipo { get; set; }
    }
}
