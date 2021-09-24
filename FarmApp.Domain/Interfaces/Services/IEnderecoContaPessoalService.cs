using FarmApp.Domain.Models.Poco;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Services
{
    public interface IEnderecoContaPessoalService : IBaseService<EnderecoContapessoalPoco>
    {
        Task<int> GetIdEnderecoContaPessoalAsync(int idTipoEndereco, int idCep, string numero, string complemento, int idContaPessoal);
    }
}
