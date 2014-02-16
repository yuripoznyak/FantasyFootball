using System;
using System.Collections.Generic;

namespace FantasyFootball.Common.Wrappers
{
    public sealed class MatchWrapper
    {
        public MatchWrapper()
        {
            this.MatchsAction = new HashSet<MatchsActionWrapper>();
        }
    
        public int Id { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
        public DateTime? MatchDate { get; set; }
    
        public ICollection<MatchsActionWrapper> MatchsAction { get; set; }
    }
}
