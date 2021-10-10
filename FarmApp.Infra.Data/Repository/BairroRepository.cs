using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Models.Poco;
using FarmApp.Infra.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace FarmApp.Infra.Data.Repository
{
    public class BairroRepository : BaseRepository<BairroPoco>, IBairroRepository
    {
        public BairroRepository(Db_FarmAppContext db_FarmAppContext) : base(db_FarmAppContext)
        {

        }

        public async Task<BairroPoco> GetBairroIfExists(string nomeBairro)
        {
            var bairros = await GetAllAsync();

            return bairros
                .Where(x => x.NomeBairro == nomeBairro)
                .FirstOrDefault();
        }
    }
}
