using FarmApp.Domain.Models;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Repositories
{
    public interface ITipoEnderecoRepository : IBaseRepository<TipoEndereco>
    {
        Task<TipoEndereco> GetTipoEnderecoPorNomeAsync(string nome);
    }
}
