using FarmApp.Domain.Models;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Repositories
{
    public interface IEnderecoRepository : IBaseRepository<Endereco>
    {
        Task<Endereco> EnderecoExistsAsync(Endereco endereco);
    }
}
