using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models;
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
                return BadRequest(ex);
            }
        }


    }
}
