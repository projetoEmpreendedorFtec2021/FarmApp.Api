using FarmApp.Domain.Models.Poco;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Services
{
    public interface IUfService : IBaseService<UfPoco>
    {
        Task<int> GetIdUfAsync(string nomeUf);
    }
}
