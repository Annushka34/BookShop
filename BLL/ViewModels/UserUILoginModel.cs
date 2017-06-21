using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels
{
    public class UserUILoginModel
    {
        public UserUILoginModel(User user)
        {
            UserId = user.Id;
            UserLogin = user.Login;
            IsAdmin = false;
            IsCustomer = false;
            if (user.Admin != null)
                IsAdmin = true;
            if (user.Customer != null)
                IsCustomer = true;
        }
        public UserUILoginModel() { }
        public int UserId { get; set; }
        public string UserLogin { get; set; }
        public bool IsCustomer { get; set; }
        public bool IsAdmin { get; set; }
        public int BasketRecordsCount { get; set; }
    }

    public class UserViewModel
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }

    public class UserViewModelLogin
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public enum UserRole
    {
        Admin = 1,
        Customer
    }
    public enum UserStatus
    {
        Success = 1,
        DublicationLogin,
        TransactionDispose,
    }
}
