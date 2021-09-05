using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FarmApp.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastraCliente(ClienteDTO cliente)
        {
            try
            {
                var criouCliente = await _clienteService.CadastraCliente(cliente);
                return Ok(criouCliente);
            }
            catch(Exception ex)
            {
                return BadRequest(new { Mensagem = ex });
            }
        }

        [HttpGet("VerificaEmail")]
        public async Task<IActionResult> VerificaEmail(int idCliente)
        {
            try
            {
                var verificouEmail = await _clienteService.VerificaEmail(idCliente);
                if (verificouEmail)
                {
                    return Ok("E-mail verificado, obrigado por utilizar o FarmApp");
                }
                return BadRequest("Não foi possível verificar o e-mail, entre em contato com o time de suporte");
                
            }
            catch(Exception ex)
            {
                return BadRequest(new { Mensagem = ex });
            }
        }

    }
}
