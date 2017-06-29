using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels
{        
    public class OrderRecordUIModel
    {
        public string Count { get; set; }
        public string OrderId { get; set; }
        public string BookName { get; set; }
        public string CloseDate { get; set; }
    }
}
