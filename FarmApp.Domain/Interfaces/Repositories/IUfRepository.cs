using FarmApp.Domain.Models;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Repositories
{
    public interface IUfRepository : IBaseRepository<Uf>
    {
        Task<Uf> GetUfByNomeAsync(string nome);
    }
}
