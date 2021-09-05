using FarmApp.Domain.Models;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Services
{
    public interface IContaPessoalService : IBaseService<ContaPessoal>
    {
        Task<int> GetIdContaPessoalAsync();
    }
}
