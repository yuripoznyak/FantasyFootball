using System;
using System.Collections.Generic;
using FantasyFootball.Common.Dto;

namespace FantasyFootball.Common.Wrappers
{
    public sealed class UserWrapper
    {
        public UserWrapper()
        {
            this.UserInRole = new HashSet<UserInRoleWrapper>();
        }
    
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? UsersTeamId { get; set; }
    
        public UsersTeamWrapper UsersTeam { get; set; }
        public ICollection<UserInRoleWrapper> UserInRole { get; set; }
    }
}
