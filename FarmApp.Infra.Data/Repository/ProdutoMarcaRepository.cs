using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Models.Poco;
using FarmApp.Infra.Data.Context;

namespace FarmApp.Infra.Data.Repository
{
    public class ProdutoMarcaRepository : BaseRepository<ProdutoMarcaPoco>, IProdutoMarcaRepository
    {
        public ProdutoMarcaRepository(Db_FarmAppContext db) : base(db)
        {
        }
    }
}