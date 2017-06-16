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
        bool DeleteOrder(int orderId);


        #region Get
        List<Order> GetAllOrdersByCustomer(Customer customer);
        Order GetOrderById(int orderId);
        DateTime GetTimePurchase(Order order);
        #endregion

       
    }
}
