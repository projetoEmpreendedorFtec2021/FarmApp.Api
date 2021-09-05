using FarmApp.Domain.Models;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Repositories
{
    public interface IConsentimentoRepository : IBaseRepository<Consentimento>
    {
        Task<Consentimento> ConsentimentoExists(string finalidade, string situacao, int idCliente);
    }
}
