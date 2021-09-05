using FarmApp.Domain.Models;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Repositories
{
    public interface ICepRepository : IBaseRepository<Cep>
    {
        Task<Cep> CepExistsAsync(Cep cep);
    }
}
