using fcs.api.Models;

namespace fcs.api.Data.Repositories.Interfaces
{
    public interface ICivilizationRepository
    {
        Task<Civilization> GetByIdAsync(int id);
        Task<IEnumerable<Civilization>> GetAllAsync();
        Task AddAsync(Civilization civilization);
        void Update(Civilization civilization);
        void Delete(Civilization civilization);
    }
}
