using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.AbstractRepository;
using DAL.Entity;

namespace DAL.ConcreteRepositories
{
   public class OrderRecordRepository:IOrderRecordsRepository
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
            try
            {
                OrderRecord orderRecord = _db.OrderRecords.SingleOrDefault(x => x.Id == orderRecordId);
                _db.OrderRecords.Remove(orderRecord);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region GET
        public List<OrderRecord> GetOrderRecordsByOrder(Order order)
        {
            List<OrderRecord> orderRecords = _db.OrderRecords.Where(x => x.Order == order).ToList();
            return orderRecords;
        }
        public List<OrderRecord> GetOrderRecordsByCustomer(Customer customer)
        {
            List<OrderRecord> orderRecords = _db.OrderRecords.Where(x => x.Order.Customer == customer).ToList();
            return orderRecords;
        }
        #endregion
    }
}
