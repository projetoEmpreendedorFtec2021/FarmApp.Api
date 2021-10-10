using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Models.Poco;
using FarmApp.Infra.Data.Context;

namespace FarmApp.Infra.Data.Repository
{
    public class ContaPessoalRepository : BaseRepository<ContaPessoalPoco>, IContaPessoalRepository
    {
        public ContaPessoalRepository(Db_FarmAppContext db_FarmAppContext) : base(db_FarmAppContext)
        {

        }
    }
}
