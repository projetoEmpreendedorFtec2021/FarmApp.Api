using FarmApp.Domain.Models.Poco;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Repositories
{
    public interface ITipoEnderecoRepository : IBaseRepository<TipoEnderecoPoco>
    {
        Task<TipoEnderecoPoco> GetTipoEnderecoPorNomeAsync(string nome);
    }
}
