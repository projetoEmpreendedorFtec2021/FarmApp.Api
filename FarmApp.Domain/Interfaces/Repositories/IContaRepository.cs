using FarmApp.Domain.Models.Poco;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Repositories
{
    public interface IContaRepository : IBaseRepository<ContaPoco>
    {
        Task<ContaPoco> GetContaPorIdContaPessoalAsync(int idContaPessoal);
    }
}
