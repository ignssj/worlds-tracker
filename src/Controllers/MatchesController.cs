using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Controllers
{

    [Route("api/matches")]
    [ApiController]

    public class MatchesController(WorldsContext context) : ControllerBase
    {
        private readonly WorldsContext _context = context;


        [HttpGet("{id}")]
        public async Task<ActionResult<Match>> GetMatch(int id)
        {
            var match = await _context.Matches.FindAsync(id);
            if (match == null) return NotFound();
            return match;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Match>>> GetMatches()
        {
            return await _context.Matches.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Match>> CreateMatch(Match match)
        {
            _context.Matches.Add(match);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMatch), new { id = match.Id }, match);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateMatch(int id, Match match)
        {
            if (id != match.Id) return BadRequest();

            _context.Entry(match).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var matchExists = _context.Matches.Any(e => e.Id == id);
                if (!matchExists) return NotFound();
                else throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatch(int id)
        {
            var match = await _context.Matches.FindAsync(id);
            if (match == null) return NotFound();
            _context.Matches.Remove(match);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }

}