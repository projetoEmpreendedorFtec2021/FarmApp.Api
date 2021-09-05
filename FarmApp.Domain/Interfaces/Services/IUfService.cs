using FarmApp.Domain.Models;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Services
{
    public interface IUfService : IBaseService<Uf>
    {
        Task<int> GetIdUfAsync(string nomeUf);
    }
}
