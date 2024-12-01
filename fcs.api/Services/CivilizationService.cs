using fcs.api.Data.UnitOfWork.Interfaces;
using fcs.api.DTOs;
using fcs.api.Models;
using fcs.api.Services.Interfaces;
using fcs.api.Utils;

namespace fcs.api.Services
{
    public class CivilizationService : ICivilizationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CivilizationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CivilizationResponseDto> CreateCivilizationAsync(CreateCivilizationDto dto)
        {
            var civilization = Mappings.ToDomainModel(dto);

            civilization.Events = [];
            civilization.Events.Add(EventGenerator.GenerateCreationEvent(civilization));

            await _unitOfWork.Civilizations.AddAsync(civilization);
            await _unitOfWork.CompleteAsync();

            return Mappings.ToResponseDto(civilization);
        }


        public async Task<CivilizationResponseDto> GetCivilizationAsync(int id)
        {
            var civilization = await _unitOfWork.Civilizations.GetByIdAsync(id);
            return Mappings.ToResponseDto(civilization);
        }

        public async Task<IEnumerable<CivilizationResponseDto>> GetAllCivilizationsAsync()
        {
            var civilizations = await _unitOfWork.Civilizations.GetAllAsync();
            return civilizations.Select(Mappings.ToResponseDto);
        }

        public async Task<CivilizationResponseDto> EvolveCivilizationAsync(int id, int turns)
        {
            var civilization = await _unitOfWork.Civilizations.GetByIdAsync(id);

            for (int i = 0; i < turns; i++)
            {
                var randomEvent = EventGenerator.GenerateRandomEvent(civilization);
                civilization.Events.Add(randomEvent);
            }

            _unitOfWork.Civilizations.Update(civilization);
            await _unitOfWork.CompleteAsync();

            return Mappings.ToResponseDto(civilization);
        }
    }
}
