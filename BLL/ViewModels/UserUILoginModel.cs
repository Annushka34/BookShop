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
            BasketRecords = new List<BasketRecordUIModel>();
        }
        public UserUILoginModel()
        {
            BasketRecords = new List<BasketRecordUIModel>();
        }
        public int UserId { get; set; }
        public string UserLogin { get; set; }
        public bool IsCustomer { get; set; }
        public bool IsAdmin { get; set; }
        public List<BasketRecordUIModel> BasketRecords { get; set; }
    }
}
