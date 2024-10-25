using worlds_tracker.src.Dtos.Match;
using worlds_tracker.src.Models;

namespace worlds_tracker.src.Mappers
{
    public static class MatchMapper
    {
        public static MatchDto ToMatchDto(this Match matchModel)
        {
            return new MatchDto
            {
                Id = matchModel.Id,
                Date = matchModel.Date,
                Team1Id = matchModel.Team1Id,
                Team2Id = matchModel.Team2Id,
                Team1 = matchModel.Team1,
                Team2 = matchModel.Team2,
                Result = matchModel.Result
            };
        }

        public static Match ToMatchFromCreateDto(this CreateMatchRequestDto createMatchRequestDto)
        {
            return new Match
            {
                Date = createMatchRequestDto.Date,
                Team1Id = createMatchRequestDto.Team1Id,
                Team2Id = createMatchRequestDto.Team2Id,
                Result = createMatchRequestDto.Result
            };
        }

        public static Match ToMatchFromUpdateDto(this UpdateMatchRequestDto updateMatchRequestDto)
        {
            return new Match
            {
                Id = updateMatchRequestDto.Id,
                Date = updateMatchRequestDto.Date,
                Team1Id = updateMatchRequestDto.Team1Id,
                Team2Id = updateMatchRequestDto.Team2Id,
                Result = updateMatchRequestDto.Result
            };
        }

    }
}