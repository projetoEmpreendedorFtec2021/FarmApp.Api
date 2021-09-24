using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models.Poco;

namespace FarmApp.Service.Services
{
    public class ItemClienteService : BaseService<ItemClientePoco>, IItemClienteService
    {
        public ItemClienteService(IItemClienteRepository itemClienteRepository) : base(itemClienteRepository)
        {
        }
    }
}
