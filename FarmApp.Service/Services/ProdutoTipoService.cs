using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models.Poco;

namespace FarmApp.Service.Services
{
    public class ProdutoTipoService : BaseService<ProdutoTipoPoco>, IProdutoTipoService
    {
        public ProdutoTipoService(IProdutoTipoRepository produtoTipoRepository) : base(produtoTipoRepository)
        {

        }
    }
}
