using FantasyFootball.Common.Wrappers;

namespace FantasyFootball.Common.Wrappers
{
    public class UserInRoleWrapper
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual RoleWrapper Role { get; set; }
        public virtual UserWrapper User { get; set; }
    }
}
