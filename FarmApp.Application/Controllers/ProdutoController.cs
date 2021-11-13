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
    [Authorize]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoMarcaService _produtoMarcaService;
        private readonly IPesquisaProdutoService _pesquisaProdutoService;
        public ProdutoController(
            IProdutoMarcaService produtoMarcaService,
            IPesquisaProdutoService pesquisaProdutoService)
        {
            _produtoMarcaService = produtoMarcaService;
            _pesquisaProdutoService = pesquisaProdutoService;
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

        [HttpGet("PesquisaProdutoPorPrecoOuDistancia")]
        public async Task<IActionResult> PesquisaItemFarmaciaPorPrecoOuDistanciaAsync([FromQuery]PesquisaProdutoDTO pesquisaProduto)
        {
            try
            {
                var produtos = await _pesquisaProdutoService.GetPesquisaProdutoPorPrecoOuDistanciaAsync(pesquisaProduto);
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message, ex.InnerException });
            }
        }
    }
}
