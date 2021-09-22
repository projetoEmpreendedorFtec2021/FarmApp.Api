using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models;

namespace FarmApp.Service.Services
{
    public class ApresentacaoProdutoService : BaseService<ApresentacaoProduto>, IApresentacaoProdutoService
    {
        public ApresentacaoProdutoService(IApresentacaoProdutoRepository apresentacaoProdutoRepository) : base(apresentacaoProdutoRepository)
        {

        }
    }
}
