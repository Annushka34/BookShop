using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace DAL.AbstractRepository
{
    public interface IOrderRepository
    {
        Order CreateOrder(Order order);
        bool DeleteOrder(Order order);
        bool UpdateOrder(Order orderOld, Order ordertNew);
        bool AddOrderForCustomer(Order order, Customer customer);


        #region OrderRecord
        Order AddOrderRecordForOrder(Order order, OrderRecord orderRecord);
        bool DeleteOrderRecordForOrder(Order order, OrderRecord orderRecord);
        #endregion


        #region Get
        List<Order> GetAllOrdersByCustomer(Customer customer);
        Order GetOrderById(int orderId);
        DateTime GetTimePurchase(Order order);
        #endregion

       
    }
}
