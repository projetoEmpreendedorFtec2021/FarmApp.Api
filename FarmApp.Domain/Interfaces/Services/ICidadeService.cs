using FarmApp.Domain.Models;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Services
{
    public interface ICidadeService : IBaseService<Cidade>
    {
        Task<int> GetIdCidadeAsync(string nomeCidade, int idUf);
    }
}
