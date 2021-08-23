using FarmApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FarmApp.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> GetCliente(string login, string senha);
    }
}
