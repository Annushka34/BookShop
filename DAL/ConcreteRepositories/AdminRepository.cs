using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.AbstractRepository;
using DAL.Entity;

namespace DAL.ConcreteRepositories
{
   public class AdminRepository: IAdminRepository
   {
        private MyContext _db;
        public AdminRepository(MyContext db)
        {
            _db = db;
        }
        public Admin GetAdminById(int userId)
        {
            var admin = _db.Admins.SingleOrDefault(u => u.UserId == userId);
            return admin;
        }

        public Admin CreateAdmin(User user)
        {
            Admin admin=new Admin();
            admin.User = user;
            _db.Admins.Add(admin);
            _db.SaveChanges();
            return admin;
        }

        public bool DeleteAdmin(int userId)
        {
            try
            {
                Admin admin = _db.Admins.SingleOrDefault(x => x.UserId == userId);
                _db.Admins.Remove(admin);//??
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
