using FarmApp.Domain.Models;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces
{
    public interface ILoginService
    {
        Task<string> GeraToken(string login, string senha);
    }
}
