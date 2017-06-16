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
        Admin CreateAdmin(User user);
        bool DeleteAdmin(int userId);

        #region Get
        Admin GetAdminById(int userId);
        #endregion
    }
}
