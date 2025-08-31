using HelloApi.Data;
using HelloApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloApi.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly AppDbContext _context;

        public PersonaRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Persona>> GetAllPersonasAsync()
        {
            return await _context.Personas.OrderBy(m => m.Id).ToListAsync();
        }

    }
}
