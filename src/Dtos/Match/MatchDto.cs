using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace worlds_tracker.src.Dtos.Match
{
    public class MatchDto
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int? Team1Id { get; set; }
        public int? Team2Id { get; set; }
        public Models.Team? Team1 { get; set; }
        public Models.Team? Team2 { get; set; }
        public string Result { get; set; } = string.Empty;
    }
}