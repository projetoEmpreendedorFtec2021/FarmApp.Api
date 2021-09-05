using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Models;
using FarmApp.Infra.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace FarmApp.Infra.Data.Repository
{
    public class CepRepository : BaseRepository<Cep>, ICepRepository
    {
        public CepRepository(Db_FarmAppContext db_farmAppContext) : base(db_farmAppContext)
        {

        }

        public async Task<Cep> CepExistsAsync(Cep cep)
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
