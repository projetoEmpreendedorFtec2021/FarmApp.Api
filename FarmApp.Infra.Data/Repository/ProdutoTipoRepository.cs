using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Models;
using FarmApp.Infra.Data.Context;

namespace FarmApp.Infra.Data.Repository
{
    public class ProdutoTipoRepository : BaseRepository<ProdutoTipo>, IProdutoTipoRepository
    {
        public ProdutoTipoRepository(Db_FarmAppContext db) : base(db)
        {

        }
    }
}
