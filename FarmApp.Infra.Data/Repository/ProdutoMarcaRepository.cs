using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Models;
using FarmApp.Infra.Data.Context;

namespace FarmApp.Infra.Data.Repository
{
    public class ProdutoMarcaRepository : BaseRepository<ProdutoMarca>, IProdutoMarcaRepository
    {
        public ProdutoMarcaRepository(Db_FarmAppContext db) : base(db)
        {
        }
    }
}
