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
    public class ItemClienteController : ControllerBase
    {
        private readonly IItemClienteService _itemClienteService;
        public ItemClienteController(IItemClienteService itemClienteService)
        {
            _itemClienteService = itemClienteService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddItensCliente([FromQuery]ItemClienteDTO itenClienteDTO)
        {
            try
            {
                bool addedAllItens = await _itemClienteService.AddItensClienteAsync(itenClienteDTO);
                return Ok(addedAllItens);
            }
            catch(Exception ex)
            {
                return BadRequest(new { Message = ex });
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllItensPorCliente(int idCliente)
        {
            try
            {
                var produtosMarca = await _itemClienteService.GetAllItensCliente(idCliente);
                return Ok(produtosMarca);
            }
            catch(Exception ex)
            {
                return BadRequest(new { Message = ex });
            }
        }
    }
}
