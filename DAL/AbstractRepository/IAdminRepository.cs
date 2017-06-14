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
        bool IsAdmin(int userId);

        bool CreateAdmin(User user);
    }
}
