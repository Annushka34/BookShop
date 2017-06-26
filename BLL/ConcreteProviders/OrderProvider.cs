using BLL.AbstractProviders;
using System.Collections.Generic;
using BLL.ViewModels;
using DAL.AbstractRepository;
using DAL.ConcreteRepositories;
using DAL.Entity;

namespace BLL.ConcreteProviders
{
    public class OrderProvider : IOrderProvider
    {
        MyContext _db;
        public OrderProvider()
        {
            _db = new MyContext();
        }
        public List<OrderRecordUIModel> GetAllOrderRecordsByCustomer(int customerId)
        {
            IOrderRecordsRepository orderRecordRepository = new OrderRecordRepository(_db);
            List<OrderRecordUIModel> orderRecordList = new List<OrderRecordUIModel>();
            var orders = orderRecordRepository.GetOrderRecordsByCustomer(customerId);
            foreach (OrderRecord order in orders)
            {
                OrderRecordUIModel newOrder = new OrderRecordUIModel(order);
                orderRecordList.Add(newOrder);
            }

            return orderRecordList;


        }

        public List<OrderUIModel> GetAllOrdersByCustomer(int customerId)
        {
            IOrderRepository orderRepository = new OrderRepository(_db);
            List<OrderUIModel> orderList = new List<OrderUIModel>();
            var orders = orderRepository.GetAllOrdersByCustomer(customerId);
            foreach (Order order in orders)
            {
                OrderUIModel newOrder = new OrderUIModel(order);
                newOrder.OrderRecords = GetAllOrderRecordsByCustomer(customerId);
                orderList.Add(newOrder);
            }
            return orderList;
        }
    }
}
