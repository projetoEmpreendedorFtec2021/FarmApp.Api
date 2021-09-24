using FarmApp.Domain.Models.Poco;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Repositories
{
    public interface IConsentimentoRepository : IBaseRepository<ConsentimentoPoco>
    {
        Task<ConsentimentoPoco> ConsentimentoExists(string finalidade, string situacao, int idCliente);
    }
}
