using DAL.AbstractRepository;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ConcreteRepositories
{
    public class OrderRepository : IOrderRepository
    {
        MyContext _db;
        public OrderRepository(MyContext db)
        {
            _db = db;
        }
        #region CRUD
        public Order CreateOrder(Order order)
        {
            _db.Orders.Add(order);
            _db.SaveChanges();
            return order;
        }

        public bool DeleteOrder(int orderId)
        {
            Order order = GetOrderById(orderId);
            if (order == null)
            {
                return false;
            }
            _db.Orders.Remove(order);
            _db.SaveChanges();
            return true;
        }
        #endregion

        #region GET
        public List<Order> GetAllOrdersByCustomer(int customerId)
        {
            List<Order> orders = _db.Orders.Where(x => x.CustomerId == customerId).ToList();
            return orders;
        }

        public List<Order> GetAllOrdersByDate(DateTime date)
        {
            List<Order> orders = _db.Orders.Where(x => x.CloseDate == date).ToList();
            return orders;
        }
        public Order GetOrderById(int orderId)
        {
            Order order = _db.Orders.SingleOrDefault(x => x.Id == orderId);
            return order;
        }
        #endregion
    }
}
