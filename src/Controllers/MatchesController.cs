using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using worlds_tracker.src.Data;
using worlds_tracker.src.Dtos.Match;
using worlds_tracker.src.Mappers;
using worlds_tracker.src.Models;

namespace worlds_tracker.src.Controllers
{
    [Route("api/matches")]
    [ApiController]
    public class MatchesController(WorldsContext context) : ControllerBase
    {
        private readonly WorldsContext _context = context;

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MatchDto>> GetMatch([FromRoute] int id)
        {
            var match = await _context.Matches.FindAsync(id);
            if (match == null) return NotFound();

            return match.ToMatchDto();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MatchDto>>> GetMatches()
        {
            var list = await _context.Matches.ToListAsync();
            return list.Select(m => m.ToMatchDto()).ToList();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<CreateMatchRequestDto>> CreateMatch([FromBody] CreateMatchRequestDto matchRequestDto)
        {
            var matchModel = matchRequestDto.ToMatchFromCreateDto();
            _context.Matches.Add(matchModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMatch), new { id = matchModel.Id }, matchRequestDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateMatch([FromRoute] int id, [FromBody] UpdateMatchRequestDto matchRequestDto)
        {
            if (id != matchRequestDto.Id) return BadRequest();

            var matchExists = await _context.Matches.FindAsync(id);
            if (matchExists == null) return NotFound();

            var matchEntity = matchRequestDto.ToMatchFromUpdateDto();

            _context.Entry(matchEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMatch([FromRoute] int id)
        {
            var match = await _context.Matches.FindAsync(id);
            if (match == null) return NotFound();

            _context.Matches.Remove(match);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }

}