using fcs.api.Data.Repositories.Interfaces;
using fcs.api.Models;
using Microsoft.EntityFrameworkCore;

namespace fcs.api.Data.Repositories
{
    public class CivilizationRepository : ICivilizationRepository
    {
        private readonly AppDbContext _context;

        public CivilizationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Civilization> GetByIdAsync(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Civilizations
                .Include(c => c.Resources)
                .Include(c => c.Events)    
                .FirstOrDefaultAsync(c => c.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
        }


        public async Task<IEnumerable<Civilization>> GetAllAsync()
        {
            return await _context.Civilizations
                .Include(c => c.Resources)
                .Include(c => c.Events)
                .ToListAsync();
        }

        public async Task AddAsync(Civilization civilization)
        {
            await _context.Civilizations.AddAsync(civilization);
        }

        public void Update(Civilization civilization)
        {
            _context.Civilizations.Update(civilization);
        }

        public void Delete(Civilization civilization)
        {
            _context.Civilizations.Remove(civilization);
        }
    }

}
