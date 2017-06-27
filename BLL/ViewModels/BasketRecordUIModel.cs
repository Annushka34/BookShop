using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels
{
   public class BasketRecordUIModel//список позицій в кошику на юай
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public int Count { get; set; }
    }

    public class BasksetRecordViewModel
    {
        public BasksetRecordViewModel(int customerId,int bookId, AddOrEditStatus status)
        {
            CustomerId = customerId;
            BookId = bookId;
            BasketRecordStatus = status;
            BookCount = 1;
        }
        public int CustomerId { get; set; }
        public int BookCount { get; set; }
        public int BookId { get; set; }
        public AddOrEditStatus BasketRecordStatus { get; set; }
    }

    public enum AddOrEditStatus
    {
        Add = 1,
        Edit = 2
    }

    public class BasketRecordInfoUIModel
    {
        public BasketRecordInfoUIModel()
        {

        }
    }


}
