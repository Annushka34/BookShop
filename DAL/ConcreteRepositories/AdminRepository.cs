using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.AbstractRepository;
using DAL.Entity;

namespace DAL.ConcreteRepositories
{
    public class AdminRepository : IAdminRepository
    {
        private MyContext _db;
        public AdminRepository(MyContext db)
        {
            _db = db;
        }

        #region CRUD
        public Admin CreateAdmin(User user)
        {
            Admin admin = new Admin();
            admin.User = user;
            _db.Admins.Add(admin);
            _db.SaveChanges();
            return admin;
        }




        public bool DeleteAdminByUserId(int userId)
        {
            Admin admin = GetAdminById(userId);
            if (admin == null)
                return false;

            _db.Admins.Remove(admin);
            _db.SaveChanges();
            return true;
        }
        #endregion

        #region GET
        public Admin GetAdminById(int userId)
        {
            var admin = _db.Admins.SingleOrDefault(u => u.UserId == userId);
            return admin;
        }
        #endregion
    }
}
