using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Models;
using FarmApp.Infra.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace FarmApp.Infra.Data.Repository
{
    public class ConsentimentoRepository : BaseRepository<Consentimento>, IConsentimentoRepository
    {
        public ConsentimentoRepository(Db_FarmAppContext db) : base(db)
        {

        }

        public async Task<Consentimento> ConsentimentoExists(string finalidade, string situacao, int idCliente)
        {
            var consentimentos = await GetAllAsync();
            return consentimentos
                .FirstOrDefault(x => x.Finalidade == finalidade 
                && x.Situacao == situacao 
                && x.Idcliente == idCliente);
        }
    }
}
