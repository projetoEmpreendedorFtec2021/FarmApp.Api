using FarmApp.Domain.Models.Poco;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Repositories
{
    public interface IUfRepository : IBaseRepository<UfPoco>
    {
        Task<UfPoco> GetUfByNomeAsync(string nome);
    }
}
