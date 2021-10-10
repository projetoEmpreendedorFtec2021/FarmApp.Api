using FarmApp.Domain.Models.Poco;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Services
{
    public interface IContaService : IBaseService<ContaPoco>
    {
        Task<int> GetIdContaFromContaPessoalAsync(int idContaPessoal);
    }
}
