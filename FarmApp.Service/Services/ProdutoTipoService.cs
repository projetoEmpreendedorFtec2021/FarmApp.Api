using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models;

namespace FarmApp.Service.Services
{
    public class ProdutoTipoService : BaseService<ProdutoTipo>, IProdutoTipoService
    {
        public ProdutoTipoService(IProdutoTipoRepository produtoTipoRepository) : base(produtoTipoRepository)
        {

        }
    }
}
