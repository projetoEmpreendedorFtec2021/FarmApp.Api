using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Models;
using FarmApp.Infra.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace FarmApp.Infra.Data.Repository
{
    public class UfRepository : BaseRepository<Uf>, IUfRepository
    {
        public UfRepository(Db_FarmAppContext db_FarmAppContext) : base(db_FarmAppContext)
        {

        }

        public async Task<Uf> GetUfByNomeAsync(string nome)
        {
            var ufs = await GetAllAsync();

            return ufs
                .Where(x => x.NomeUf == nome)
                .FirstOrDefault();
        }
    }
}
