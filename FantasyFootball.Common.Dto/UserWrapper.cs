using System;
using System.Collections.Generic;

namespace FantasyFootball.Common.Wrappers
{
    public sealed class UserWrapper
    {
        public UserWrapper()
        {
            this.UserInRole = new HashSet<UserInRoleWrapper>();
        }
    
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? UsersTeamId { get; set; }
        public bool IsLockOut { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime LastActivityDate { get; set; }
        public DateTime LastPasswordChange { get; set; }
        public DateTime LastLockoutDate { get; set; }

    
        public UsersTeamWrapper UsersTeam { get; set; }
        public ICollection<UserInRoleWrapper> UserInRole { get; set; }
    }
}
