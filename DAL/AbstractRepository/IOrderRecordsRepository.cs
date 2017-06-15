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
        OrderRecord CreateOrderRecord(OrderRecord orderRecord);
        bool UpdateOrderRecord(OrderRecord orderRecordOld, OrderRecord orderRecordNew);


        #region Get
        List<OrderRecord> GetOrderRecordsByOrder(Order order);
        List<OrderRecord> GetOrderRecordsByUser(User user);
        #endregion

    }
}
