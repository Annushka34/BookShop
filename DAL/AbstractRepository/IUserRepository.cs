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
        User CreateUser(User user);
        bool DeleteUser(User user);
        bool Update(int userOldId, User userNew);


        #region Get
        User GetUserById(int userId);
        User GetUserByLogin(string login);
        #endregion
    }
}
