using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Models;
using FarmApp.Infra.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace FarmApp.Infra.Data.Repository
{
    public class ContaRepository : BaseRepository<Conta>, IContaRepository
    {
        public ContaRepository(Db_FarmAppContext db_FarmAppContext) : base(db_FarmAppContext)
        {
            
        }

        public async Task<Conta> GetContaPorIdContaPessoalAsync(int idContaPessoal)
        {
            var contas = await GetAllAsync();

            return contas
                .Where(x => x.IdcontaPessoal == idContaPessoal)
                .FirstOrDefault();
        }
    }
}
