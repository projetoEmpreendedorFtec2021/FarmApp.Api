using FarmApp.Domain.Models;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Services
{
    public interface IEnderecoContaPessoalService : IBaseService<EnderecoContapessoal>
    {
        Task<int> GetIdEnderecoContaPessoalAsync(int idTipoEndereco, int idCep, string numero, string complemento, int idContaPessoal);
    }
}
