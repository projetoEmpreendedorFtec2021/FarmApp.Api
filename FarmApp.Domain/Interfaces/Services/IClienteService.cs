using FarmApp.Domain.Models;
using FarmApp.Domain.Models.DTO;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Services
{
    public interface IClienteService: IBaseService<Cliente>
    {
        Task<bool> CadastraCliente(ClienteDTO cliente);
        bool IsEmailCadastrado(string email);
    }
}
