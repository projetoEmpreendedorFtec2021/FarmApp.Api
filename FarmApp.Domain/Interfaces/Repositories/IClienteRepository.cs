using FarmApp.Domain.Models.Poco;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Repositories
{
    public interface IClienteRepository: IBaseRepository<ClientePoco>
    {
        Task<ClientePoco> GetCliente(string login, string senha);
        ClientePoco GetClientePorEmail(string email);
    }
}
