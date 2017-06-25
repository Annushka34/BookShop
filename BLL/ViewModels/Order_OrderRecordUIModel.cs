using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels
{
    public class OrderUIModel
    {
        public OrderUIModel(Order order)
        {
            Id = order.Id;
            CloseDate = order.CloseDate;
            CustomerId = order.CustomerId;
            OrderRecords = new List<OrderRecordUIModel>();
        }
        public int Id { get; set; }
        public DateTime CloseDate { get; set; }
        public int CustomerId { get; set; }
        public List<OrderRecordUIModel> OrderRecords { get; set; }
    }
    public class OrderRecordUIModel
    {
        public OrderRecordUIModel(OrderRecord orderRecord)
        {
            Id = orderRecord.Id;
            Count = orderRecord.Count;
            OrderId = orderRecord.OrderId;
            BookId = orderRecord.BookId;
        }
        public int Id { get; set; }
        public int Count { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
    }
}
