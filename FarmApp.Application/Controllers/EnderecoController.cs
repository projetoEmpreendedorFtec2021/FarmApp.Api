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
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;
        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet]
        [AllowAnonymous]
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

        [HttpPost("AddFromLatLong")]
        [Authorize]
        public async Task<IActionResult> AddEnderecoFromLatELong([FromBody]EnderecoLatLongDTO endereco)
        {
            try
            {
                return Ok(await _enderecoService.AddEnderecoCompletoAsync(endereco));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex });
            }
        }
    }
}
