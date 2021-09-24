using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models.Poco;

namespace FarmApp.Service.Services
{
    public class MarcaService : BaseService<MarcaPoco>, IMarcaService
    {
        public MarcaService(IMarcaRepository marcaRepository) : base(marcaRepository)
        {

        }
    }
}
