using fcs.api.DTOs;

namespace fcs.api.Services.Interfaces
{
    public interface ICivilizationService
    {
        Task<CivilizationResponseDto> CreateCivilizationAsync(CreateCivilizationDto dto);
        Task<CivilizationResponseDto> GetCivilizationAsync(int id);
        Task<IEnumerable<CivilizationResponseDto>> GetAllCivilizationsAsync();
        Task<CivilizationResponseDto> EvolveCivilizationAsync(int id, int turns);
    }
}
