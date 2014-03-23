using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using FantasyFootball.Common.Wrappers;
using FantasyFootball.Common.Mappers;
using FantasyFootball.Common.SqlContext;

namespace FantasyFootball.Common.Services
{
    public class UserService : IDisposable
    {
        private readonly FantasyEntities _dataContext = new FantasyEntities();

        private DbSet<User> Entity
        {
            get { return _dataContext.User; }
        }

        private User Get(int id)
        {
            return Entity.FirstOrDefault(x => x.Id == id);
        }

        public UserWrapper Get(string username)
        {
            var user = Entity.FirstOrDefault(x => x.Username == username);
            return user == null ? null : user.ToUserWrapper();
        }

        public IEnumerable<UserWrapper> GetAll()
        {
            var items = Entity.ToList();
            var list = new List<UserWrapper>();
            foreach (var item in items)
            {
                list.Add(item.ToUserWrapper());
            }

            return list;
        }

        public bool AddItem(UserWrapper item)
        {
            var dbItem = item.ToDatabaseUser();
            Entity.Add(dbItem);

            return SaveChanges();
        }

        public bool RemoveItem(UserWrapper item)
        {
            Entity.Remove(item.ToDatabaseUser());

            return SaveChanges(); ;
        }

        public bool UpdateItem(UserWrapper item)
        {
            var user = Entity.FirstOrDefault(x => x.Id == item.Id);
            if (user == null)
            {
                return false;
            }
            var newUser = item.ToDatabaseUser();
            user.Password = newUser.Password;
            user.LastActivityDate = newUser.LastActivityDate;
            user.Email = newUser.Email;
            user.LastPasswordChange = newUser.LastPasswordChange;

            return SaveChanges();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }

        public bool SaveChanges()
        {
            try
            {
                _dataContext.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationError in dbEx.EntityValidationErrors.SelectMany(validationErrors => validationErrors.ValidationErrors))
                {
                    Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                }
                return false;
            }
        }
    }
}
