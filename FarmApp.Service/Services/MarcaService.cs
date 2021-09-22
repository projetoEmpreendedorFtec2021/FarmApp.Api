using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models;

namespace FarmApp.Service.Services
{
    public class MarcaService : BaseService<Marca>, IMarcaService
    {
        public MarcaService(IMarcaRepository marcaRepository) : base(marcaRepository)
        {

        }
    }
}
