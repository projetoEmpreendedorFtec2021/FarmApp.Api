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
        private readonly IConsentimentoRepository _consentimentoRepository;
        public LoginService(
            IClienteRepository clienteRepository,
            IContaRepository contaRepository,
            IConsentimentoRepository consentimentoRepository)
        {
            _clienteRepository = clienteRepository;
            _contaRepository = contaRepository;
            _consentimentoRepository = consentimentoRepository;
        }

        public async Task<(string, string)> GeraToken(string login, string senha)
        {
            var cliente = await _clienteRepository.GetCliente(login, senha);

            if (cliente is null)
            {
                return (string.Empty, "Usuário ou senha inválidos");
            }

            if (cliente.ValidaEmail is null)
            {
                return (string.Empty, "E-mail não verificado");
            }

            var consentimento = await _consentimentoRepository.ConsentimentoExists(
                "Coleta de dados de identificação pessoal", 
                "A", 
                cliente.Id);

            if(consentimento is null)
            {
                return (string.Empty, "Termos de Consentimento não foram aceitos");
            }

            var conta = await _contaRepository.GetByIdAsync(cliente.Idconta ?? null);
            if (conta is null)
            {
                return (string.Empty, "Conta não cadastrada");
            }

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
             var tokenString = tokenHandler.WriteToken(token);

            return (tokenString, string.Empty);
            

        }
    }
}
