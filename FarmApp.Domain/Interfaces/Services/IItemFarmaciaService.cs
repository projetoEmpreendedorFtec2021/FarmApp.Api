using FarmApp.Domain.Models.DTO;
using FarmApp.Domain.Models.Poco;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Services
{
    public interface IItemFarmaciaService : IBaseService<ItemFarmaciaPoco>
    {
        Task<bool> AddOrUpdateItensFarmaciaAsync(IList<ItemFarmaciaDTO> itens);
        Task DeleteItemFarmaciaAsync(int idItemFarmacia);
    }
}
