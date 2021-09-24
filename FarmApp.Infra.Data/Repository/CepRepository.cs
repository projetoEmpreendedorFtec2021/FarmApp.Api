using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Models.Poco;
using FarmApp.Infra.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace FarmApp.Infra.Data.Repository
{
    public class CepRepository : BaseRepository<CepPoco>, ICepRepository
    {
        public CepRepository(Db_FarmAppContext db_farmAppContext) : base(db_farmAppContext)
        {

        }

        public async Task<CepPoco> CepExistsAsync(CepPoco cep)
        {
            if (cep is null)
            {
                throw new System.ArgumentNullException(nameof(cep));
            }

            var ceps = await GetAllAsync();

            return ceps
                .Where(x => x.NumeroCep == cep.NumeroCep && x.Idendereco == cep.Idendereco)
                .FirstOrDefault();
        }
    }
}
