using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels
{
    public class UserUIDataModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public UserRole UserRole { get; set; }
        List<BasketRecordUIModel> BasketRecords { get; set; }
    }
}
