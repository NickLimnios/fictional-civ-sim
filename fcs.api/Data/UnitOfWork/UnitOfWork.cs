using fcs.api.Data.Repositories.Interfaces;
using fcs.api.Data.UnitOfWork.Interfaces;

namespace fcs.api.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public ICivilizationRepository Civilizations { get; }

        public UnitOfWork(AppDbContext context, ICivilizationRepository civilizationRepository)
        {
            _context = context;
            Civilizations = civilizationRepository;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
