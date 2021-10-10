using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models.Poco;

namespace FarmApp.Service.Services
{
    public class ApresentacaoProdutoService : BaseService<ApresentacaoProdutoPoco>, IApresentacaoProdutoService
    {
        public ApresentacaoProdutoService(IApresentacaoProdutoRepository apresentacaoProdutoRepository) : base(apresentacaoProdutoRepository)
        {

        }
    }
}
