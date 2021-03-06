//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FantasyFootball.Common.SqlContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.UserInRole = new HashSet<UserInRole>();
        }
    
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsLockOut { get; set; }
        public Nullable<int> UsersTeamId { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> LastLoginDate { get; set; }
        public Nullable<System.DateTime> LastActivityDate { get; set; }
        public Nullable<System.DateTime> LastPasswordChange { get; set; }
        public Nullable<System.DateTime> LastLockoutDate { get; set; }
    
        public virtual UsersTeam UsersTeam { get; set; }
        public virtual ICollection<UserInRole> UserInRole { get; set; }
    }
}
