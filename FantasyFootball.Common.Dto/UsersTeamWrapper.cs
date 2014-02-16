using System;
using System.Collections.Generic;
using FantasyFootball.Common.Dto;

namespace FantasyFootball.Common.Wrappers
{
    public sealed class UsersTeamWrapper
    {
        public UsersTeamWrapper()
        {
            this.User = new HashSet<UserWrapper>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int? LeagueId { get; set; }
    
        public LeagueWrapper League { get; set; }
        public ICollection<UserWrapper> User { get; set; }
    }
}
