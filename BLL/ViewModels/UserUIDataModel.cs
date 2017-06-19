using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels
{
    public class UserUIDataModel
    {
        public UserUIDataModel(User user)
        {
            UserId = user.Id;
            UserName = user.Login;
            UserRole = UserRole.Customer;
        }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public UserRole UserRole { get; set; }
        List<BasketRecordUIModel> BasketRecords { get; set; }
    }
}
