using FarmApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FarmApp.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;
        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEnderecoFromCEP(string CEP) 
        {
            try
            {
                var enderecoDTO = await _enderecoService.GetEnderecoFromCEPAsync(CEP);
                return Ok(enderecoDTO);
            }
            catch(Exception ex)
            {
                return BadRequest(new { Mensagem = ex });
            }
            

        }
    }
}
