using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using System.Web.Security;
using FantasyFootball.Common.Services;
using FantasyFootball.Common.Wrappers;
using WebMatrix.WebData;

namespace FantasyFootball.Custom.Implementation.Providers
{
    public class FantasyMembershipProvider : ExtendedMembershipProvider
    {
        private readonly UserService _userService = new UserService();
        
        #region Properties
        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override string ApplicationName
        {
            get { return GetType().Assembly.GetName().Name; }
            set { ApplicationName = GetType().Assembly.GetName().Name; }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { return 10; }
        }

        public override int PasswordAttemptWindow
        {
            get { return 0; }
        }

        public override bool RequiresUniqueEmail
        {
            get { return true; }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { return MembershipPasswordFormat.Hashed; }
        }

        public override int MinRequiredPasswordLength
        {
            get { return 6; }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { return 0; }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { return String.Empty; }
        }

        #endregion

        #region NotImplemented
        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion,
            string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }
        
        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override ICollection<OAuthAccountData> GetAccountsForUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override string CreateUserAndAccount(string userName, string password, bool requireConfirmation, IDictionary<string, object> values)
        {
            throw new NotImplementedException();
        }

        public override string CreateAccount(string userName, string password, bool requireConfirmationToken)
        {
            throw new NotImplementedException();
        }

        public override bool ConfirmAccount(string userName, string accountConfirmationToken)
        {
            throw new NotImplementedException();
        }

        public override bool ConfirmAccount(string accountConfirmationToken)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteAccount(string userName)
        {
            throw new NotImplementedException();
        }

        public override string GeneratePasswordResetToken(string userName, int tokenExpirationInMinutesFromNow)
        {
            throw new NotImplementedException();
        }

        public override int GetUserIdFromPasswordResetToken(string token)
        {
            throw new NotImplementedException();
        }

        public override bool IsConfirmed(string userName)
        {
            throw new NotImplementedException();
        }

        public override bool ResetPasswordWithToken(string token, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override int GetPasswordFailuresSinceLastSuccess(string userName)
        {
            throw new NotImplementedException();
        }

        public override DateTime GetCreateDate(string userName)
        {
            throw new NotImplementedException();
        }

        public override DateTime GetPasswordChangedDate(string userName)
        {
            throw new NotImplementedException();
        }

        public override DateTime GetLastPasswordFailureDate(string userName)
        {
            throw new NotImplementedException();
        }
        #endregion

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer,
            bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            if (string.IsNullOrEmpty(username))
            {
                status = MembershipCreateStatus.InvalidUserName;
                return null;
            }
            if (String.IsNullOrEmpty(password))
            {
                status = MembershipCreateStatus.InvalidPassword;
                return null;
            }
            if (String.IsNullOrEmpty(email))
            {
                status = MembershipCreateStatus.InvalidEmail;
                return null;
            }

            string hashedPassword = Crypto.HashPassword(password);
            if (hashedPassword.Length > 128)
            {
                status = MembershipCreateStatus.InvalidPassword;
                return null;
            }

            var users = _userService.GetAll();
            var userWrappers = users as IList<UserWrapper> ?? users.ToList();
            if (userWrappers.Any(x => x.Email == email))
            {
                status = MembershipCreateStatus.DuplicateEmail;
                return null;
            }
            if (userWrappers.Any(x => x.Username == username))
            {
                status = MembershipCreateStatus.DuplicateUserName;
                return null;
            }

            UserWrapper user = new UserWrapper()
            {
                Email = email,
                Username = username,
                Password = hashedPassword,
                CreateDate = DateTime.Now,
                IsLockOut = false,
                LastActivityDate = DateTime.Now,
                LastPasswordChange = DateTime.Now,
                LastLoginDate = DateTime.Now,
                LastLockoutDate = DateTime.Now
            };

            if (_userService.AddItem(user))
            {
                status = MembershipCreateStatus.Success;
                user = _userService.Get(username);
                var membershipUser = new MembershipUser(Membership.Provider.Name, user.Username, user.Id, user.Email, null, null, true,
                    user.IsLockOut, user.CreateDate, user.LastLoginDate, user.LastActivityDate, user.LastPasswordChange,
                    user.LastLockoutDate);
                return membershipUser;
            }

            status = MembershipCreateStatus.ProviderError;
            return null;
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            if (String.IsNullOrEmpty(username))
            {
                return false;
            }
            if (String.IsNullOrEmpty(oldPassword))
            {
                return false;
            }
            if (String.IsNullOrEmpty(newPassword))
            {
                return false;
            }

            var user = _userService.Get(username);
            if (user == null)
            {
                return false;
            }

            var verficationSucceeded = (user.Password != null &&
                                         Crypto.VerifyHashedPassword(user.Password, oldPassword));
            var hashedPassword = Crypto.HashPassword(newPassword);
            if (hashedPassword.Length > 128)
            {
                return false;
            }
            user.Password = hashedPassword;
            user.LastPasswordChange = DateTime.Now;
            return _userService.UpdateItem(user);
        }


        public override bool ValidateUser(string username, string password)
        {
            if (String.IsNullOrEmpty(username))
            {
                return false;
            }
            if (String.IsNullOrEmpty(password))
            {
                return false;
            }

            var user = _userService.Get(username);
            if (user.IsLockOut || user == null)
            {
                return false;
            }

            var verficationSucceeded = (user.Password != null &&
                                         Crypto.VerifyHashedPassword(user.Password, password));
            if (verficationSucceeded)
            {
                user.LastLoginDate = DateTime.Now;
                user.LastActivityDate = DateTime.Now;
                _userService.UpdateItem(user);
            }

            return verficationSucceeded;
        }

        public override bool UnlockUser(string userName)
        {
            var user = _userService.Get(userName);
            if (user == null) return false;
            user.IsLockOut = false;
            _userService.UpdateItem(user);
            return true;
        }
        
        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            if (String.IsNullOrEmpty(username))
            {
                return null;
            }

            var user = _userService.Get(username);
            if (user != null)
            {
                return new MembershipUser(Membership.Provider.Name, user.Username, user.Id, user.Email, null, null, true,
                    user.IsLockOut, user.CreateDate, user.LastLoginDate, user.LastActivityDate, user.LastPasswordChange,
                    user.LastLockoutDate);
            }
            
            return null;
        }
        
        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            if (String.IsNullOrEmpty(username))
            {
                return false;
            }

            var user = _userService.Get(username);
            return user != null && _userService.RemoveItem(user);
        }
    }
}
