using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models.DTO;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IContaFarmaciaService _contaFarmaciaService;

        public ClienteController(
            IClienteService clienteService,
            IContaFarmaciaService contaFarmaciaService)
        {
            _clienteService = clienteService;
            _contaFarmaciaService = contaFarmaciaService;
        }

        [HttpPost]
        [AllowAnonymous]
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
        [AllowAnonymous]
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

        [HttpPost("CadastraContaFarmacia")]
        public async Task<IActionResult> CadastraContaFarmacia(ContaFarmaciaDTO contaFarmaciaDTO)
        {
            try
            {
                var cadastrouContaFarmacia = await _contaFarmaciaService.CadastraContaFarmaciaAsync(contaFarmaciaDTO);

                return Ok(cadastrouContaFarmacia);
            }
            catch(Exception ex)
            {
                return BadRequest(new { Mensagem = ex });
            }
        }
    }
}
