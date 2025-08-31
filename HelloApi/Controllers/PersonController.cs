using HelloApi.Models;
using HelloApi.Models.Dtos;
using HelloApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelloApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoController : ControllerBase
    {
        private readonly IService<Person> _service;

        public EquipoController(IService<Person> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> Get()
        {
            var equipos = await _service.GetAllAsync();
            return Ok(equipos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> Get(int id)
        {
            var equipo = await _service.GetByIdAsync(id);
            if (equipo == null)
                return NotFound();
            return Ok(equipo);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePersonDto dto)
        {
            var equipo = new Person
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                CreatedAt = DateTime.UtcNow
            };
            await _service.CreateAsync(equipo);
            return Ok("Equipo agregado");
        }
    }
}