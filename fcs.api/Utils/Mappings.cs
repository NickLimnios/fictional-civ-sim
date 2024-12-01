using fcs.api.DTOs;
using fcs.api.Models;

namespace fcs.api.Utils
{
    public static class Mappings
    {
        public static CivilizationResponseDto ToResponseDto(Civilization civilization)
        {
            return new CivilizationResponseDto
            {
                Id = civilization.Id,
                Name = civilization.Name,
                CurrentYear = civilization.CurrentYear,
                Population = civilization.Population,
                Resources = civilization.Resources.Select(r => new ResourceDto
                {
                    Name = r.Name,
                    Quantity = r.Quantity
                }).ToList(),
                Events = civilization.Events.Select(e => new EventDto
                {
                    Year = e.Year,
                    Description = e.Description
                }).ToList(),
            };
        }

        public static Civilization ToDomainModel(CreateCivilizationDto dto)
        {

            var resources = dto?.Resources != null ? dto.Resources.Select(kvp => new Resource
            {
                Name = kvp.Key,
                Quantity = kvp.Value
            }).ToList() : [];

            return new Civilization
            {
                Name = dto.Name,
                CurrentYear = dto.CurrentYear,
                Population = dto.Population,
                Resources = resources,
                Climate = dto.Climate,
                Culture = dto.Culture,
                Technology = dto.Technology,
            };
        }
    }

}
