using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Models.Poco;
using FarmApp.Infra.Data.Context;

namespace FarmApp.Infra.Data.Repository
{
    public class ProdutoTipoRepository : BaseRepository<ProdutoTipoPoco>, IProdutoTipoRepository
    {
        public ProdutoTipoRepository(Db_FarmAppContext db) : base(db)
        {

        }
    }
}
