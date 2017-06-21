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

        public bool DeleteUser(int userId)
        {
            User user = GetUserById(userId);
            if (user == null)
            {
                return false;
            }
            _db.Users.Remove(user);
            _db.SaveChanges();
            return true;
        }

        public User Update(User userOld, User userNew)
        {
                userOld.Login = userNew.Login;
                userOld.Password = userNew.Password;
                userOld.Email = userNew.Email;
                userOld.Admin = userNew.Admin;
                userOld.Customer = userNew.Customer;
                _db.SaveChanges();
                return userOld;
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
