using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Models;
using FarmApp.Infra.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace FarmApp.Infra.Data.Repository
{
    public class CidadeRepository : BaseRepository<Cidade>, ICidadeRepository
    {
        public CidadeRepository(Db_FarmAppContext db_FarmAppContext) : base(db_FarmAppContext)
        {

        }

        public async Task<Cidade> GetCidadeIfExists(string nomeCidade, int idUf)
        {
            var cidades = await GetAllAsync();

            return cidades
                .Where(x => x.NomeCidade == nomeCidade && x.Iduf == idUf)
                .FirstOrDefault();
        }
    }
}
