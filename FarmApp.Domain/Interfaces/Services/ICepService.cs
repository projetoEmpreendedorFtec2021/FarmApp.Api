using FarmApp.Domain.Models.Poco;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Services
{
    public interface ICepService : IBaseService<CepPoco>
    {
        Task<int> GetIdCepAsync(string numeroCep, int idEndereco);
        Task<CepPoco> AddCepIfNotExists(string numeroCep, int idEndereco);
    }
}
