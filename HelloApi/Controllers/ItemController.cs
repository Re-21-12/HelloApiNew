using HelloApi.Models.Dtos;
using HelloApi.Services;
using Microsoft.AspNetCore.Mvc;
using HelloApi.Services;
using HelloApi.Models;
namespace HelloApi.Controllers
{   //Haga un endpoint o un controlador 
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        //Inyectar un servicio
        private readonly IService<Item> _service;
        
        //Inyectar un servicio
        public ItemController(IService<Item> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _service.GetAllAsync();
            return Ok(items);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ItemDto itemDto)
        {
            if (itemDto == null)
            {
                return BadRequest("El objeto Order no puede ser nulo.");
            }
            var item = new Item
            {
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedAt = DateTime.UtcNow
            };
            var itemResponse = await _service.CreateAsync(item);
            return CreatedAtAction(nameof(GetAll), new { id = itemResponse.Id }, itemResponse);
        }

    }
}