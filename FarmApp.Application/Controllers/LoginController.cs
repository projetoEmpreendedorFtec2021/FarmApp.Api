using FarmApp.Domain.Interfaces;
using FarmApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FarmApp.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate([FromQuery] string login, 
            [FromQuery] string senha)
        {
            // Gera o Token
            var token = await _loginService.GeraToken(login, senha);
            if(token == null)
            {
                return NotFound(new { Mensagem = "Usuário ou senha inválidos" });
            }
            // Retorna os dados
            
            return Ok(new
            {
                token
            });
        }
    }
}
