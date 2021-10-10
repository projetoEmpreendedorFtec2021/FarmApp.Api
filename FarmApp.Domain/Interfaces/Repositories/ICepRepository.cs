using FarmApp.Domain.Models.Poco;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Repositories
{
    public interface ICepRepository : IBaseRepository<CepPoco>
    {
        Task<CepPoco> CepExistsAsync(CepPoco cep);
    }
}
