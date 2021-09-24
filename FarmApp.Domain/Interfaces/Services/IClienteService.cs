using FarmApp.Domain.Models.DTO;
using FarmApp.Domain.Models.Poco;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Services
{
    public interface IClienteService: IBaseService<ClientePoco>
    {
        Task<bool> CadastraCliente(ClienteDTO cliente);
        Task<bool> VerificaEmail(int idCliente);
    }
}
