using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Models;
using FarmApp.Infra.Data.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FarmApp.Infra.Data.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly Db_FarmAppContext _db_FarmAppContext;
        public ClienteRepository(Db_FarmAppContext db_FarmAppContext) : base(db_FarmAppContext)
        {
            _db_FarmAppContext = db_FarmAppContext;
        }

        public async Task<Cliente> GetCliente(string login, string senha)
        {
            try
            {
                var clientes = await GetAllAsync();

                var cliente = clientes.FirstOrDefault(x => x.Login == login && x.Senha == senha);

                return cliente;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public Cliente GetClientePorEmail(string email)
        {
            var cliente = _db_FarmAppContext
                .Set<Cliente>()
                .Where(x => x.Login == email)
                .FirstOrDefault();

            return cliente;
        }
    }
}
