using FarmApp.Domain.Models.Poco;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Services
{
    public interface ICidadeService : IBaseService<CidadePoco>
    {
        Task<int> GetIdCidadeAsync(string nomeCidade, int idUf);
    }
}
