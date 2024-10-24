using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using worlds_tracker.src.Dtos.Team;
using worlds_tracker.src.Models;

namespace worlds_tracker.src.Mappers
{
    public static class TeamMapper
    {
        public static TeamDto ToTeamDto(this Team teamModel)
        {
            return new TeamDto
            {
                Id = teamModel.Id,
                Name = teamModel.Name,
                Region = teamModel.Region,
                Points = teamModel.Points,
                Matches = teamModel.Matches
            };
        }
    }
}