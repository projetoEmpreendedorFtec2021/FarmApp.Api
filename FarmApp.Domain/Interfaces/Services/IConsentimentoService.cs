using FarmApp.Domain.Models;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Services
{
    public interface IConsentimentoService : IBaseService<Consentimento>
    {
        Task AddConsentimento(int idCliente, string situacao);
    }
}
