using FarmApp.Domain.Interfaces.Repositories;
using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FarmApp.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoMarcaService _produtoMarcaService;
        public ProdutoController(IProdutoMarcaService produtoMarcaService)
        {
            _produtoMarcaService = produtoMarcaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProdutosPorTipo([FromQuery]ProdutoDTO produtoDTO)
        {
            try
            {
                var produtos = await _produtoMarcaService.GetProdutosPorTipoAsync(produtoDTO);
                return Ok(produtos);
            }
            catch(Exception ex)
            {
                return BadRequest(new { Message = ex });
            }
        }
    }
}
