using worlds_tracker.src.Data;
using Microsoft.EntityFrameworkCore;
using worlds_tracker.src.Interfaces;
using worlds_tracker.src.Models;
using worlds_tracker.src.Dtos.Match;

namespace worlds_tracker.src.Repositories
{
    public class MatchRepository(WorldsContext context) : IMatchRepository
    {
        private readonly WorldsContext _context = context;

        public async Task<Match> CreateAsync(Match match)
        {
            await _context.Matches.AddAsync(match);
            await _context.SaveChangesAsync();
            return match;
        }

        public async Task<Match?> DeleteAsync(int id)
        {
            var matchModel = await _context.Matches.FirstOrDefaultAsync(x => x.Id == id);
            if (matchModel == null) return null;

            _context.Matches.Remove(matchModel);
            await _context.SaveChangesAsync();
            return matchModel;
        }

        public async Task<IEnumerable<Match>> FindAllAsync()
        {
            return await _context.Matches.ToListAsync();
        }

        public async Task<Match?> FindOneAsync(int id)
        {
            return await _context.Matches.FindAsync(id);
        }

        public async Task<Match?> UpdateAsync(int id, UpdateMatchRequestDto body)
        {
            var match = await _context.Matches.FirstOrDefaultAsync(x => x.Id == id);
            if (match == null) return null;

            _context.Entry(match).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return match;
        }
    }
}