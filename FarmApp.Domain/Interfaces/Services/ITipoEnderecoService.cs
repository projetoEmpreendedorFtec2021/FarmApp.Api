using FarmApp.Domain.Models.Poco;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Services
{
    public interface ITipoEnderecoService : IBaseService<TipoEnderecoPoco>
    {
        Task<TipoEnderecoPoco> GetTipoEnderecoByNomeAsync(string nome);
    }
}
