using FarmApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FarmApp.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
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
            var token = await _loginService.GeraToken(login, senha);
            if(token == null)
            {
                return NotFound(new { Mensagem = "Usuário ou senha inválidos" });
            }
            
            return Ok(new
            {
                token
            });
        }
    }
}
