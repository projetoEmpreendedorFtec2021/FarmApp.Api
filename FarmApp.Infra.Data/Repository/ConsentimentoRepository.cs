using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Models.Poco;
using FarmApp.Infra.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace FarmApp.Infra.Data.Repository
{
    public class ConsentimentoRepository : BaseRepository<ConsentimentoPoco>, IConsentimentoRepository
    {
        public ConsentimentoRepository(Db_FarmAppContext db) : base(db)
        {

        }

        public async Task<ConsentimentoPoco> ConsentimentoExists(string finalidade, string situacao, int idCliente)
        {
            var consentimentos = await GetAllAsync();
            return consentimentos
                .FirstOrDefault(x => x.Finalidade == finalidade 
                && x.Situacao == situacao 
                && x.Idcliente == idCliente);
        }
    }
}
