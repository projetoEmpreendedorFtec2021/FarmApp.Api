using FarmApp.Domain.Models;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Services
{
    public interface IContaService : IBaseService<Conta>
    {
        Task<int> GetIdContaAsync(int idContaPessoal);
    }
}
