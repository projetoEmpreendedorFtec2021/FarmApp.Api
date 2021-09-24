using FarmApp.Domain.Models.Poco;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Services
{
    public interface IConsentimentoService : IBaseService<ConsentimentoPoco>
    {
        Task AddConsentimento(int idCliente, string situacao);
    }
}
