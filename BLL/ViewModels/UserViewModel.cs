using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels
{
    public class UserViewModel
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
    public enum UserRole
    {
        Admin = 1,
        Customer = 2
    }
    public enum UserStatus
    {
        Success = 1,
        DublicationLogin,
        TransactionDispose,
        IncorrectLogin,
        IncorrectPassword
    }
}
