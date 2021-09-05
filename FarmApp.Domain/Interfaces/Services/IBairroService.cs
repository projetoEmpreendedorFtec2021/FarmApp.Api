using FarmApp.Domain.Models;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Services
{
    public interface IBairroService : IBaseService<Bairro>
    {
        Task<int> GetIdBairroAsync(string nomeBairro);
    }
}
