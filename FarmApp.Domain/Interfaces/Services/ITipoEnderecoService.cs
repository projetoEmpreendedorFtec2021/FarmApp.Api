using FarmApp.Domain.Models;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Services
{
    public interface ITipoEnderecoService : IBaseService<TipoEndereco>
    {
        Task<TipoEndereco> GetTipoEnderecoByNomeAsync(string nome);
    }
}
