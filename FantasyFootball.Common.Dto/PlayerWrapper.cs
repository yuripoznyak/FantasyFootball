using System.Collections.Generic;

namespace FantasyFootball.Common.Wrappers
{
    public sealed class PlayerWrapper
    {
        public PlayerWrapper()
        {
            this.MatchsAction = new HashSet<MatchsActionWrapper>();
        }
    
        public int Id { get; set; }
        public int TeamId { get; set; }
        public string Name { get; set; }
    
        public ICollection<MatchsActionWrapper> MatchsAction { get; set; }
        public TeamWrapper Team { get; set; }
    }
}
