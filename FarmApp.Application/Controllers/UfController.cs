using FarmApp.Domain.Interfaces;
using FarmApp.Domain.Interfaces.Services;
using FarmApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FarmApp.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UfController : ControllerBase
    {
        private readonly IBaseService<Uf> _service;
        public UfController(IBaseService<Uf> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUfs()
        {
            return Ok(await _service.GetAllAsync());
        }
    }
}
