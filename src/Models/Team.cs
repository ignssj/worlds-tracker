using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace worlds_tracker.src.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public int Points { get; set; } = 0;
        public List<Match> Matches { get; set; } = new List<Match>();
    }
}