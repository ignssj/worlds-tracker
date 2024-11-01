using worlds_tracker.src.Dtos.Match;
using worlds_tracker.src.Models;

namespace worlds_tracker.src.Interfaces
{
    public interface IMatchRepository
    {
        Task<Match?> FindOneAsync(int id);
        Task<IEnumerable<Match>> FindAllAsync();
        Task<Match> CreateAsync(Match entity);
        Task<Match?> UpdateAsync(int id, UpdateMatchRequestDto entity);
        Task<Match?> DeleteAsync(int id);
    }
}