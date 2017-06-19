using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.AbstractRepository;
using DAL.Entity;

namespace DAL.ConcreteRepositories
{
    public class OrderRecordRepository : IOrderRecordsRepository
    {
        MyContext _db;
        public OrderRecordRepository(MyContext db)
        {
            _db = db;
        }
        #region CRUD
        public OrderRecord CreateOrderRecord(OrderRecord orderRecord)
        {
            _db.OrderRecords.Add(orderRecord);
            _db.SaveChanges();
            return orderRecord;
        }
        public bool DeleteOrderRecord(int orderRecordId)
        {
            OrderRecord orderRecord = GetOrderRecordById(orderRecordId);
            if (orderRecord == null)
            {
                return false;
            }
            _db.OrderRecords.Remove(orderRecord);
            _db.SaveChanges();
            return true;
        }
        #endregion

        #region GET
        public OrderRecord GetOrderRecordById(int orderRecordId)
        {
            OrderRecord orderRecord = _db.OrderRecords.SingleOrDefault(x => x.Id == orderRecordId);
            return orderRecord;
        }
        public List<OrderRecord> GetOrderRecordsByOrder(int orderId)
        {
            List<OrderRecord> orderRecords = _db.OrderRecords.Where(x => x.Id == orderId).ToList();
            return orderRecords;
        }
        public List<OrderRecord> GetOrderRecordsByCustomer(int customerId)
        {
            List<OrderRecord> orderRecords = _db.OrderRecords.Where(x => x.Order.CustomerId == customerId).ToList();
            return orderRecords;
        }
        #endregion
    }
}
