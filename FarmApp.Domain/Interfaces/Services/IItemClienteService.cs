using FarmApp.Domain.Models;
using FarmApp.Domain.Models.DTO;
using FarmApp.Domain.Models.Poco;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Services
{
    public interface IItemClienteService : IBaseService<ItemClientePoco>
    {
        Task<bool> AddItensClienteAsync(ItemClienteDTO itemClienteDTO);
        Task<IList<ProdutoMarca>> GetAllItensCliente(int idCliente);
    }
}
