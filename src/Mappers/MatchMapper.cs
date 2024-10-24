using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}