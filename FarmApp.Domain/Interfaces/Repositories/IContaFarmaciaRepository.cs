using FarmApp.Domain.Models.Poco;

namespace FarmApp.Domain.Interfaces.Repositories
{
    public interface IContaFarmaciaRepository : IBaseRepository<ContaFarmaciaPoco>
    {
        ContaFarmaciaPoco GetContaFarmaciaPorEmail(string email);
    }
}
