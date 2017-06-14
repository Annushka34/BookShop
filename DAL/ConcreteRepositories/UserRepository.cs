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
            throw new NotImplementedException();
        }

        public bool Create(User user)
        {
            db=new MyContext();
            db.Users.Add(user);
            db.SaveChanges();
            return true;
        }

        public bool Delete(User user)
        {
            throw new NotImplementedException();
        }

        public User Read(int userId)
        {
            throw new NotImplementedException();
        }

        public User ReadByLogin(string login)
        {
            throw new NotImplementedException();
        }

        public bool Update(User userOld, User userNew)
        {
            throw new NotImplementedException();
        }
    }
}
