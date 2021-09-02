using FarmApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces.Repositories
{
    public interface IClienteRepository: IBaseRepository<Cliente>
    {
        Task<Cliente> GetCliente(string login, string senha);
        Cliente GetClientePorEmail(string email);
    }
}
