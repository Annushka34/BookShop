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
        #region CRUD
        Order CreateOrder(Order order);
        bool DeleteOrder(int orderId);
        #endregion

        #region Get
        List<Order> GetAllOrdersByCustomer(int customerId);
        List<Order> GetAllOrdersByDate(DateTime date);
        Order GetOrderById(int orderId);
        #endregion

       
    }
}
