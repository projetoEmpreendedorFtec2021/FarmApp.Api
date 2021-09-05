using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Services 
{ 
    public interface ILoginService
    {
        Task<string> GeraToken(string login, string senha);
    }
}
