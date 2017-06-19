using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.ViewModels;
using DAL.Entity;

namespace BLL.AbstractProviders
{
    public interface IUserProvider
    {
        UserStatus UserRegistration(UserViewModel user);
        UserUIDataModel UserLogin(UserViewModelLogin user);
        
    }
}
