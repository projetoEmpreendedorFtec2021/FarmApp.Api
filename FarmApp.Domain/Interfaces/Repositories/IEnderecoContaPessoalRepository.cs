using FarmApp.Domain.Models.Poco;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Repositories
{
    public interface IEnderecoContaPessoalRepository : IBaseRepository<EnderecoContapessoalPoco>
    {
        Task<EnderecoContapessoalPoco> EnderecoContaPessoalExists(
            int idTipoEndereco,
            int idCep,
            string numero,
            string complemento,
            int idContaPessoal);
    }
}
