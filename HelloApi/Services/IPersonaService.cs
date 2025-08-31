using HelloApi.Models.Dtos;

namespace HelloApi.Services
{
    public interface IPersonaService
    {
        Task<IEnumerable<PersonaReadDto>> GetAllPersonasAsync();
    }
}
