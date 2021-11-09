using FarmApp.Domain.Models.Poco;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Repositories
{
    public interface IItemFarmaciaRepository : IBaseRepository<ItemFarmaciaPoco>
    {
        Task<IList<ItemFarmaciaPoco>> GetItensFarmaciaByIdContaFarmaciaAsync(int idContaFarmacia);
    }
}
