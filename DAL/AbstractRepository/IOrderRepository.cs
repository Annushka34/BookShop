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
        Order CreateOrder(Customer customer);
        bool DeleteOrder(int orderId);
        #endregion

        #region Get
        List<Order> GetAllOrdersByCustomer(Customer customer);
        List<Order> GetAllOrdersByDate(DateTime date);
        Order GetOrderById(int orderId);
        #endregion

       
    }
}
