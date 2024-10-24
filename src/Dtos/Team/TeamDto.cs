using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using worlds_tracker.src.Models;

namespace worlds_tracker.src.Dtos.Team
{
    public class TeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public int Points { get; set; } = 0;
        public List<Models.Match> Matches { get; set; } = new List<Models.Match>();
    }
}