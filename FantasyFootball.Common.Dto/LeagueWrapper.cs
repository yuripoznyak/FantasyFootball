using System.Collections.Generic;
using FantasyFootball.Common.Wrappers;

namespace FantasyFootball.Common.Wrappers
{
    public sealed class LeagueWrapper
    {
        public LeagueWrapper()
        {
            this.UsersTeam = new HashSet<UsersTeamWrapper>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public ICollection<UsersTeamWrapper> UsersTeam { get; set; }
    }
}
