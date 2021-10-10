using FarmApp.Domain.Models.Poco;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Repositories
{
    public interface ICidadeRepository : IBaseRepository<CidadePoco>
    {
        Task<CidadePoco> GetCidadeIfExists(string nomeCidade, int idUf);
    }
}
