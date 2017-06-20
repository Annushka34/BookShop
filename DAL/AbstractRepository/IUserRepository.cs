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
        #region CRUD
        User CreateUser(User user);
        bool DeleteUser(int userId);
        User Update(User userOld, User userNew);
        #endregion


        #region Get
        User GetUserById(int userId);
        User GetUserByLogin(string login);
        #endregion
    }
}
