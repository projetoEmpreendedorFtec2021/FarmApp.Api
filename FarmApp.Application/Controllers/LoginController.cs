using FarmApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
            try
            {
                (var token, var errorMessage) = await _loginService.GeraToken(login, senha);
                if (token == string.Empty || token is null)
                {
                    return Unauthorized(new { Mensagem = errorMessage });
                }

                return Ok(new
                {
                    token
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new { Mensagem = ex });
            }
        }

        [HttpPost("Farmacia")]
        public async Task<IActionResult> AuthenticateContaFarmacia(
            [FromQuery] string login,
            [FromQuery] string senha)
        {
            try
            {
                (var token, var errorMessage) = await _loginService.GeraToken(
                    login,
                    senha,
                    loginFarmacia: true);

                if(token == string.Empty || token is null)
                {
                    return Unauthorized(new { Mensagem = errorMessage });
                }

                return Ok(new { token });
            }
            catch(Exception ex)
            {
                return BadRequest(new { Mensagem = ex });
            }
        }
    }
}
