using FarmApp.Domain.Interfaces;
using FarmApp.Domain.Models;
using FarmApp.Infra.Data.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FarmApp.Infra.Data.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(Db_FarmAppContext db_FarmAppContext) : base(db_FarmAppContext)
        {

        }

        public async Task<Cliente> GetCliente(string login, string senha)
        {
            var clientes = await GetAllAsync();

            var cliente = clientes.FirstOrDefault(x => x.Login == login && x.Senha == senha);

            return cliente;
        }
    }
}
