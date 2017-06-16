using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace DAL.AbstractRepository
{
    public interface IOrderRecordsRepository
    {
        OrderRecord CreateOrderRecord(Order order, OrderRecord orderRecord);
        bool DeleteOrderRecord(int orderRecordId);


        #region Get
        List<OrderRecord> GetOrderRecordsByOrder(Order order);
        List<OrderRecord> GetOrderRecordsByUser(User user);
        #endregion

    }
}
