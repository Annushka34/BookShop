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
       private MyContext db;
        public bool IsAdmin(int userId)
        { return true; }

        public bool CreateAdmin(User user)
        {
            db=new MyContext();
            Admin admin=new Admin();
            admin.UserId = user.Id;
            db.Admins.Add(admin);
            db.SaveChanges();
            return true;
        }
    }
}
