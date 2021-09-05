using FarmApp.Domain.Models;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Services
{

    public interface IMailService
    {
        Task SendEmailAsync(EmailRequest emailRequest);
    }
}
