using FarmApp.Domain.Models.DTO;
using FarmApp.Domain.Models.Poco;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Services
{
    public interface IContaFarmaciaService : IBaseService<ContaFarmaciaPoco>
    {
        Task<bool> CadastraContaFarmaciaAsync(ContaFarmaciaDTO contaFarmaciaDTO);
    }
}
