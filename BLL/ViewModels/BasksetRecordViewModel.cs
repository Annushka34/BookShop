using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;


namespace BLL.ViewModels
{
    public class BasksetRecordViewModel
    {
        public int customerId { get; set; }
        public int BookCount { get; set; }
        public int BookId { get; set; }
        public AddOrEditStatus BasketRecordStatus { get; set; }
    }

    public enum AddOrEditStatus
    {
        Add=1,Edit=2
    }
}
