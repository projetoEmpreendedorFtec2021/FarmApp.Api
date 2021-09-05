using FarmApp.Domain.Models;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Repositories
{
    public interface IContaRepository : IBaseRepository<Conta>
    {
        Task<Conta> GetContaPorIdContaPessoalAsync(int idContaPessoal);
    }
}
