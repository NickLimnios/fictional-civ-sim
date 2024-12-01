using fcs.api.Data.Repositories.Interfaces;

namespace fcs.api.Data.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICivilizationRepository Civilizations { get; }
        Task<int> CompleteAsync();
    }
}
