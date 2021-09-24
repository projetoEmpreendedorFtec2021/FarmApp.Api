using FarmApp.Domain.Models.Poco;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Repositories
{
    public interface IBairroRepository : IBaseRepository<BairroPoco>
    {
        Task<BairroPoco> GetBairroIfExists(string nomeBairro);
    }
}
