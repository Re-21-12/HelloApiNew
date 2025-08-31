using HelloApi.Models.Dtos;
using HelloApi.Services;
using Microsoft.AspNetCore.Mvc;
using HelloApi.Services;
using HelloApi.Models;
namespace HelloApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IService<Order> _service;

        public OrderController(IService<Order> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var messages = await _service.GetAllAsync();
            return Ok(messages);
        }
        [HttpPost]
        public async Task<IActionResult> Create(OrderDto orderDto)
        {
            if (orderDto == null)
            {
                return BadRequest("El objeto Order no puede ser nulo.");
            }
            var order = new Order
            {
                Number = orderDto.Number,
                PersonId = orderDto.PersonId,
                CreatedAt = DateTime.UtcNow
            };
            var createdOrder = await _service.CreateAsync(order);
            return CreatedAtAction(nameof(GetAll), new { id = createdOrder.Id }, createdOrder);
        }

    }
}