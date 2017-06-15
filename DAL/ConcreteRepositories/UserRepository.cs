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
        private MyContext db;

        public bool CheckUserLogin(string login)
        {
            db = new MyContext();
            var user = db.Users.Where(x => x.Login == login).FirstOrDefault();
            if (user != null)
            {
                return true;
            }
            else
                throw new NotImplementedException("User by this login not exists");
        }

        public bool Create(User user)
        {
            db = new MyContext();
            db.Users.Add(user);
            db.SaveChanges();
            return true;
        }

        public bool Delete(User user)
        {
            db = new MyContext();
            db.Users.Remove(user);
            db.SaveChanges();
            return true;
        }

        public User Read(int userId)
        {
            db = new MyContext();
            User user = db.Users.Find(userId);
            if (user != null)
            {
                return user;
            }
            else
                throw new NotImplementedException("Cannot read user");
        }

        public User ReadByLogin(string login)
        {
            db = new MyContext();
            var user = db.Users.Where(x => x.Login == login).FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            else
                throw new NotImplementedException("User by login not found");
        }

        public bool Update(User userOld, User userNew)
        {
            db = new MyContext();
            var user = db.Users.Find(userOld.Id);
            if (user != null)
            {
                user.Login = userNew.Login;
                user.Password = userNew.Password;
                user.Email = userNew.Email;
                user.Admin = userNew.Admin;
                user.Customer = userNew.Customer;
                db.SaveChanges();
                return true;
            }
            throw new NotImplementedException("User cannot update");
        }
    }
}
