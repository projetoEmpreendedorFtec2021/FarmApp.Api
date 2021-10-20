using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Models.Poco;
using FarmApp.Infra.Data.Context;
using System.Linq;

namespace FarmApp.Infra.Data.Repository
{
    public class ContaFarmaciaRepository : BaseRepository<ContaFarmaciaPoco>, IContaFarmaciaRepository
    {
        private readonly Db_FarmAppContext _db;
        public ContaFarmaciaRepository(Db_FarmAppContext db) : base(db)
        {
            _db = db;
        }

        public ContaFarmaciaPoco GetContaFarmaciaPorEmail(string email)
        {
            var cliente = _db
                .Set<ContaFarmaciaPoco>()
                .Where(x => x.Email == email)
                .FirstOrDefault();

            return cliente;
        }
    }
}
