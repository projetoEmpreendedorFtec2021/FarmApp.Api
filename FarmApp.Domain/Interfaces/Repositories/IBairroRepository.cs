using FarmApp.Domain.Models;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Repositories
{
    public interface IBairroRepository : IBaseRepository<Bairro>
    {
        Task<Bairro> GetBairroIfExists(string nomeBairro);
    }
}
