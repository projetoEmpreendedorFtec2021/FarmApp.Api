using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models;

namespace FarmApp.Service.Services
{
    public class ItemClienteService : BaseService<ItemCliente>, IItemClienteService
    {
        public ItemClienteService(IItemClienteRepository itemClienteRepository) : base(itemClienteRepository)
        {
        }
    }
}
