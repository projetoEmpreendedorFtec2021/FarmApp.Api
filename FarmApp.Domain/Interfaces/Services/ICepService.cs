using FarmApp.Domain.Models;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Services
{
    public interface ICepService : IBaseService<Cep>
    {
        Task<int> GetIdCepAsync(string numeroCep, int idEndereco);
        Task<Cep> AddCepIfNotExists(string numeroCep, int idEndereco);
    }
}
