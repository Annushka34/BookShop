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
        bool DeleteOrderRecord(int orderRecordId);


        #region Get
        OrderRecord GetOrderRecordById(int orderRecordId);
        List<OrderRecord> GetOrderRecordsByOrder(int orderId);
        List<OrderRecord> GetOrderRecordsByCustomer(int customerId);

        #endregion

    }
}
