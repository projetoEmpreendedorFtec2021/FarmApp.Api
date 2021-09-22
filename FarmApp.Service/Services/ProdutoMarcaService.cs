using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models;

namespace FarmApp.Service.Services
{
    public class ProdutoMarcaService : BaseService<ProdutoMarca>, IProdutoMarcaService
    {
        public ProdutoMarcaService(IProdutoMarcaRepository produtoMarcaRepository) : base(produtoMarcaRepository)
        {
        }
    }
}
