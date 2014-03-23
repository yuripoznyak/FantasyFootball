using System.Collections.Generic;

namespace FantasyFootball.Common.Wrappers
{
    public sealed class RoleWrapper
    {
        public RoleWrapper()
        {
            this.UserInRole = new HashSet<UserInRoleWrapper>();
        }
    
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
    
        public ICollection<UserInRoleWrapper> UserInRole { get; set; }
    }
}
