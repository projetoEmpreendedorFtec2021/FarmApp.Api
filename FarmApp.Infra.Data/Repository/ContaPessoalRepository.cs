using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Models;
using FarmApp.Infra.Data.Context;

namespace FarmApp.Infra.Data.Repository
{
    public class ContaPessoalRepository : BaseRepository<ContaPessoal>, IContaPessoalRepository
    {
        public ContaPessoalRepository(Db_FarmAppContext db_FarmAppContext) : base(db_FarmAppContext)
        {

        }
    }
}
