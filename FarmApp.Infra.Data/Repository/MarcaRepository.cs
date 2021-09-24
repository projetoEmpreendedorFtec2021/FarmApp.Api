using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Models.Poco;
using FarmApp.Infra.Data.Context;

namespace FarmApp.Infra.Data.Repository
{
    public class MarcaRepository : BaseRepository<MarcaPoco>, IMarcaRepository
    {
        public MarcaRepository(Db_FarmAppContext db) : base(db)
        {
        }
    }
}
