using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models.Poco;

namespace FarmApp.Service.Services
{
    public class ProdutoService : BaseService<ProdutoPoco>, IProdutoService
    {
        public ProdutoService(IProdutoRepository produtoRepository) : base(produtoRepository)
        {
        }
    }
}
