using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Models.Poco;
using FarmApp.Infra.Data.Context;

namespace FarmApp.Infra.Data.Repository
{
    public class ProdutoRepository : BaseRepository<ProdutoPoco>, IProdutoRepository
    {
        public ProdutoRepository(Db_FarmAppContext db) : base(db)
        {

        }
    }
}
