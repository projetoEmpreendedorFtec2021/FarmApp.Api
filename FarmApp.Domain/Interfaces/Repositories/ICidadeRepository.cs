using FarmApp.Domain.Models;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Repositories
{
    public interface ICidadeRepository : IBaseRepository<Cidade>
    {
        Task<Cidade> GetCidadeIfExists(string nomeCidade, int idUf);
    }
}
