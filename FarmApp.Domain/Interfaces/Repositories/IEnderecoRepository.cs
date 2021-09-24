using FarmApp.Domain.Models.Poco;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Repositories
{
    public interface IEnderecoRepository : IBaseRepository<EnderecoPoco>
    {
        Task<EnderecoPoco> EnderecoExistsAsync(EnderecoPoco endereco);
    }
}
