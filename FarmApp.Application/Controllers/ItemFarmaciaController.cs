using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FarmApp.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ItemFarmaciaController : ControllerBase
    {
        private readonly IItemFarmaciaService _itemFarmaciaService;
        public ItemFarmaciaController(
            IItemFarmaciaService itemFarmaciaService)
        {
            _itemFarmaciaService = itemFarmaciaService;
        }

        [HttpPost("AddOrUpdate")]
        public async Task<IActionResult> AddOrUpdateItensFarmaciaAsync(IList<ItemFarmaciaDTO> itensFarmacia)
        {
            try
            {
                var addedOrUpdatedItens = await _itemFarmaciaService.AddOrUpdateItensFarmaciaAsync(itensFarmacia);

                return Ok(addedOrUpdatedItens);
            }
            catch(Exception ex)
            {
                return BadRequest(new { ex.Message, ex.InnerException });
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteItemFarmaciaAsync([FromQuery] int idItemFarmacia)
        {
            try
            {
                await _itemFarmaciaService.DeleteAsync(idItemFarmacia);
                return Ok(true);
            }
            catch(Exception ex)
            {
                return BadRequest(new { ex.Message, ex.InnerException });
            }
        }
    }
}
