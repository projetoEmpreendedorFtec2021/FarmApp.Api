using FarmApp.Domain.Models.Poco;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Services
{
    public interface IBairroService : IBaseService<BairroPoco>
    {
        Task<int> GetIdBairroAsync(string nomeBairro);
    }
}
