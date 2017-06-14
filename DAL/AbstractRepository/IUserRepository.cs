using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace DAL.AbstractRepository
{
    public interface IUserRepository
    {
        bool Create(User user);
        bool Delete(User user);

        bool Update(User userOld, User userNew);

        User Read(int userId);
        User ReadByLogin(string login);

        bool CheckUserLogin(string login);
    }
}
