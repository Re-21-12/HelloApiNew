using HelloApi.Models;

namespace HelloApi.Repositories
{
    public interface IPersonaRepository
    {
        Task<IEnumerable<Persona>> GetAllPersonasAsync();

    }
}
