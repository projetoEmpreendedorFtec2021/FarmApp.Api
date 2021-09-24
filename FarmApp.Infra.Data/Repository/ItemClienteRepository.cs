using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Models.Poco;
using FarmApp.Infra.Data.Context;

namespace FarmApp.Infra.Data.Repository
{
    public class ItemClienteRepository : BaseRepository<ItemClientePoco>, IItemClienteRepository
    {
        public ItemClienteRepository(Db_FarmAppContext db) : base(db)
        {
        }
    }
}
