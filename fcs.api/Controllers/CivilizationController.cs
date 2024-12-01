using fcs.api.DTOs;
using fcs.api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace fcs.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CivilizationController : ControllerBase
    {
        private readonly ICivilizationService _service;

        public CivilizationController(ICivilizationService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCivilization([FromBody] CreateCivilizationDto dto)
        {
            var civilization = await _service.CreateCivilizationAsync(dto);
            return CreatedAtAction(nameof(GetCivilization), new { id = civilization.Id }, civilization);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCivilization(int id)
        {
            var civilization = await _service.GetCivilizationAsync(id);
            return Ok(civilization);
        }

        [HttpPut("{id}/evolve")]
        public async Task<IActionResult> EvolveCivilization(int id, [FromQuery] int turns)
        {
            var civilization = await _service.EvolveCivilizationAsync(id, turns);
            return Ok(civilization);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCivilizations()
        {
            var civilizations = await _service.GetAllCivilizationsAsync();
            return Ok(civilizations);
        }
    }


}
