using FarmApp.Domain.Models.Poco;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Services
{
    public interface IContaPessoalService : IBaseService<ContaPessoalPoco>
    {
        Task<int> GetIdContaPessoalAsync();
    }
}
