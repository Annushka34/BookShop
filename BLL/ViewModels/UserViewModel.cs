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
    }
    public enum UserStatus
    {
        Success = 1,
        DublicationEmail = 2
    }
}
