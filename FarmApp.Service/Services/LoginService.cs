using FarmApp.Domain.Interfaces;
using FarmApp.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FarmApp.Service.Services
{
    public class LoginService : ILoginService
    {
        private readonly IClienteRepository _clienteRepository;
        public LoginService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<string> GeraToken(string login, string senha)
        {
            var cliente = await _clienteRepository.GetCliente(login, senha);
            //if(cliente != null)
            if(login == "Teste" && senha == "Teste")
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(Settings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    //new Claim(ClaimTypes.Name, cliente.Login.ToString())
                    new Claim(ClaimTypes.Name, "Teste")
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
