using FarmApp.Domain.Models;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Repositories
{
    public interface IEnderecoContaPessoalRepository : IBaseRepository<EnderecoContapessoal>
    {
        Task<EnderecoContapessoal> EnderecoContaPessoalExists(
            int idTipoEndereco,
            int idCep,
            string numero,
            string complemento,
            int idContaPessoal);
    }
}
