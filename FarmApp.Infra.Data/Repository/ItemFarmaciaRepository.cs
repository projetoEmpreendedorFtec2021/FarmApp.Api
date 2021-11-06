using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Models.Poco;
using FarmApp.Infra.Data.Context;

namespace FarmApp.Infra.Data.Repository
{
    public class ItemFarmaciaRepository : BaseRepository<ItemFarmaciaPoco>, IItemFarmaciaRepository
    {
        public ItemFarmaciaRepository(Db_FarmAppContext db) : base(db)
        {

        }
    }
}
