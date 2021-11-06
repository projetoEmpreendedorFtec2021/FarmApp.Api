using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Models.Poco;
using FarmApp.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmApp.Infra.Data.Repository
{
    public class ItemFarmaciaRepository : BaseRepository<ItemFarmaciaPoco>, IItemFarmaciaRepository
    {
        private readonly Db_FarmAppContext _db;
        public ItemFarmaciaRepository(Db_FarmAppContext db) : base(db)
        {
            _db = db;
        }

        public async Task<IList<ItemFarmaciaPoco>> GetItensFarmaciaByIdContaFarmaciaAsync(int idContaFarmacia)
        {
            var itens = await GetAllAsync();

            return itens.Where(x => x.IdcontaFarmacia == idContaFarmacia).ToList();
        }
    }
}
