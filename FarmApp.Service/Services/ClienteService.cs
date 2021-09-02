using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models;
using FarmApp.Domain.Models.DTO;
using FarmApp.Service.Validators;
using System.Threading.Tasks;

namespace FarmApp.Service.Services
{
    public class ClienteService : BaseService<Cliente>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository repository) : base(repository)
        {
            _clienteRepository = repository;
        }
        public async Task<bool> CadastraCliente(ClienteDTO clienteDTO)
        {
            var cliente = ClienteBuilder
                .Init(this)
                .SetNome(clienteDTO.Nome)
                .SetLogin(clienteDTO.Email)
                .SetSenha(clienteDTO.Senha, clienteDTO.RepeteSenha)
                .SetCPF(clienteDTO.CPF)
                .Build();
            var response = await AddAsync<ClienteValidator>(cliente);
            return (response != null);
        }

        public bool IsEmailCadastrado(string email)
        {
            var cliente = _clienteRepository.GetClientePorEmail(email);
            return cliente != null;
        }
    }
}
