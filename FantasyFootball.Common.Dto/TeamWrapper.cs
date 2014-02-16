using System.Collections.Generic;

namespace FantasyFootball.Common.Wrappers
{
    public sealed class TeamWrapper
    {
        public TeamWrapper()
        {
            this.Player = new HashSet<PlayerWrapper>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int MatchesPlayed { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsConceded { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Looses { get; set; }
    
        public ICollection<PlayerWrapper> Player { get; set; }
    }
}
