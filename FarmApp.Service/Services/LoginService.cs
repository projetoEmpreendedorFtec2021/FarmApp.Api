using FarmApp.Domain.Interfaces;
using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Interfaces.Services;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FarmApp.Service.Services
{
    public class LoginService : ILoginService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IContaRepository _contaRepository;
        private const int ValidaEmail = 1;
        public LoginService(
            IClienteRepository clienteRepository,
            IContaRepository contaRepository)
        {
            _clienteRepository = clienteRepository;
            _contaRepository = contaRepository;
        }

        public async Task<string> GeraToken(string login, string senha)
        {
            var cliente = await _clienteRepository.GetCliente(login, senha);
            var conta = await _contaRepository.GetByIdAsync(cliente.Idconta.Value);
            if (cliente != null && conta != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(Settings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(type: "Nome", value: cliente.Nome),
                        new Claim(type: "Email", value: cliente.Login),
                        new Claim(type: "IdCliente", value: cliente.Id.ToString()),
                        new Claim(type: "IdContaPessoal", value: conta.IdcontaPessoal.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddHours(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            return null;
        }
    }
}
