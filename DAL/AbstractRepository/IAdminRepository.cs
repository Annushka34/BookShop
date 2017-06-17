using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace DAL.AbstractRepository
{
    public interface IAdminRepository
    {
        #region CRUD
        Admin CreateAdmin(User user);
        bool DeleteAdminByUserId(int userId);
        bool DeleteAdmin(Admin admin);
        #endregion

        #region Get
        Admin GetAdminById(int userId);
        #endregion
    }
}
