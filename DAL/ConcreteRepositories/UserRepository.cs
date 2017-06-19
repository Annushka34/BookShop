using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.AbstractRepository;
using DAL.Entity;

namespace DAL.ConcreteRepositories
{
    public class UserRepository : IUserRepository
    {
        private MyContext _db;
        public UserRepository(MyContext db)
        {
            _db = db;
        }
        #region CRUD
        public User CreateUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
            return user;
        }

        public bool DeleteUser(User user)
        {
            try
            {
                _db.Users.Remove(user);   //??
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(int userOldId, User userNew)
        {
            try
            {
                User user = _db.Users.SingleOrDefault(x => x.Id == userOldId);
                user.Login = userNew.Login;
                user.Password = userNew.Password;
                user.Email = userNew.Email;
                user.Admin = userNew.Admin;
                user.Customer = userNew.Customer;
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region GET
        public User GetUserByLogin(string login)
        {
            var user = _db.Users.SingleOrDefault(x => x.Login == login);
            return user;
        }

        public User GetUserById(int userId)
        {
            User user = _db.Users.SingleOrDefault(u => u.Id == userId);
            return user;

        }
        #endregion
    }
}
