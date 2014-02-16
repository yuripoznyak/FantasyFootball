using System.Collections.Generic;

namespace FantasyFootball.Common.Wrappers
{
    public class ActionWrapper
    {
        public ActionWrapper()
        {
            this.MatchsAction = new HashSet<MatchsActionWrapper>();
        }
    
        public int Id { get; set; }
        public string Type { get; set; }
        public int Points { get; set; }
    
        public virtual ICollection<MatchsActionWrapper> MatchsAction { get; set; }
    }
}
