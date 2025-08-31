using HelloApi.Models;
using HelloApi.Models.Dtos;
using HelloApi.Repositories;

namespace HelloApi.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository _repository;

        public PersonaService(IPersonaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PersonaReadDto>> GetAllPersonasAsync()
        {
            var entities = await _repository.GetAllPersonasAsync();
            return entities.Select(MapToReadDto);
        }
        private static PersonaReadDto MapToReadDto(Persona persona) => new()
        {
            Id = persona.Id,
            firstName = persona.firstName,
            lastName = persona.lastName,
            CreatedAt = persona.CreatedAt,
            UpdatedAt = persona.UpdatedAt
        };
    }
}
