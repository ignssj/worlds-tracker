using Microsoft.AspNetCore.Mvc;
using worlds_tracker.src.Dtos.Match;
using worlds_tracker.src.Mappers;
using worlds_tracker.src.Repositories;

namespace worlds_tracker.src.Controllers
{
    [Route("api/matches")]
    [ApiController]
    public class MatchesController(MatchRepository matchRepository) : ControllerBase
    {

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MatchDto>> GetMatch([FromRoute] int id)
        {
            var match = await matchRepository.FindOneAsync(id);
            if (match == null) return NotFound();

            return match.ToMatchDto();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MatchDto>>> GetMatches()
        {
            var list = await matchRepository.FindAllAsync();
            return list.Select(m => m.ToMatchDto()).ToList();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<CreateMatchRequestDto>> CreateMatch([FromBody] CreateMatchRequestDto matchRequestDto)
        {
            var matchModel = matchRequestDto.ToMatchFromCreateDto();
            await matchRepository.CreateAsync(matchModel);
            return CreatedAtAction(nameof(GetMatch), new { id = matchModel.Id }, matchRequestDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateMatch([FromRoute] int id, [FromBody] UpdateMatchRequestDto matchRequestDto)
        {
            await matchRepository.UpdateAsync(id, matchRequestDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMatch([FromRoute] int id)
        {
            await matchRepository.DeleteAsync(id);
            return NoContent();
        }

    }

}