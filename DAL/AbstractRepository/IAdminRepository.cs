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
        Admin GetAdminById(int userId);

        Admin CreateAdmin(User user);

        bool DeleteAdminById(int userId);
    }
}
