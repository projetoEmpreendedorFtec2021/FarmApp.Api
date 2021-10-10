using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Models.Poco;
using FarmApp.Infra.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace FarmApp.Infra.Data.Repository
{
    public class EnderecoContaPessoalRepository : BaseRepository<EnderecoContapessoalPoco>, IEnderecoContaPessoalRepository
    {
        public EnderecoContaPessoalRepository(Db_FarmAppContext db) : base(db)
        {

        }

        public async Task<EnderecoContapessoalPoco> EnderecoContaPessoalExists(
            int idTipoEndereco, 
            int idCep, 
            string numero, 
            string complemento, 
            int idContaPessoal)
        {
            var enderecos = await GetAllAsync();

            return enderecos
                .Where(x => x.IdtipoEndereco == idTipoEndereco 
                && x.Idcep == idCep 
                && x.Numero == numero
                && x.Complemento == complemento
                && x.IdcontaPessoal == idContaPessoal)
                .FirstOrDefault();
        }
    }
}
