using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.AbstractProviders;
using BLL.ViewModels;
using DAL.AbstractRepository;
using DAL.ConcreteRepositories;
using DAL.Entity;

namespace BLL.ConcreteProviders
{
    public class CustomerProvider:ICustomerProvider
    {
            MyContext _db;
        public CustomerProvider()
        {
            _db = new MyContext();
        }

        public bool AddBasketRecord(BasksetRecordViewModel basketRecordViewModel)
        {
            IBasketRepository basketRepository = new BasketRepository(_db);
            ICustomerRepository customerRepository = new CustomerRepository(_db);
            IBasketRecordRepository basketRecordRepository = new BasketRecordRepository(_db);
            //перевірка на вже існуючого користувача

            Customer customer = customerRepository.GetCustomerById(basketRecordViewModel.CustomerId);
            if (customer == null)
            {
                return false;
            }
            BasketRecord basketRecord = basketRepository.GetBasketRecordByBook(basketRecordViewModel.BookId, basketRecordViewModel.CustomerId);
            BasketRecord basketRecordNew = new BasketRecord();
            basketRecordNew.BasketId = basketRecordViewModel.CustomerId;
            basketRecordNew.BookId = basketRecordViewModel.BookId;
            basketRecordNew.Count = basketRecordViewModel.BookCount;
            if (basketRecord != null)
            {
                if (basketRecordViewModel.BasketRecordStatus == AddOrEditStatus.Add)
                    basketRecordNew.Count += basketRecord.Count;
                else
                    basketRecordNew.Count = basketRecord.Count;

                basketRecordRepository.Update(basketRecord, basketRecordNew);
            }
            else
            {               
                basketRecordNew.Count = basketRecordViewModel.BookCount;
                basketRecordRepository.CreateBasketRecord(basketRecordNew);
            }
            return true;
        }
        
        public bool CreateOrderList(int customerId)
        {
            ICustomerRepository customerRepository = new CustomerRepository(_db);
            IBasketRepository basketRepository = new BasketRepository(_db);
            IBasketRecordRepository basketRecordRepository = new BasketRecordRepository(_db);
            IOrderRepository orderRepository = new OrderRepository(_db);
            IOrderRecordsRepository orderRecordsRepository = new OrderRecordRepository(_db);
            //перевірка на вже існуючого користувача

            Customer customer = customerRepository.GetCustomerById(customerId);
            if (customer == null)
            {
                return false;
            }

            using (Transaction transaction = new Transaction())
            {
                try
                {
                    transaction.TransactionStart();

                    Basket basket = basketRepository.GetBasketById(customer.UserId);
                    var bascketRecords = basketRepository.GetBasketRecordsByBasket(basket.CustomerId); //всі поля з кошика

                    Order order = new Order();
                    order.CustomerId = basket.CustomerId;
                    order.CloseDate = DateTime.Now;
                    order = orderRepository.CreateOrder(order); ///??????

                    foreach (var records in bascketRecords)
                    {
                        OrderRecord orderRec = new OrderRecord();//нове поле замовлення
                        orderRec.BookId = records.BookId;
                        orderRec.OrderId = order.Id;
                        orderRec.Count = records.Count;
                        orderRecordsRepository.CreateOrderRecord(orderRec);
                    }
                    basketRepository.ClearBasket(customerId);

                    transaction.TransactionCommit();
                    return true;
                }
                catch
                {
                    transaction.Dispose();
                    return false;
                }
            }
        }

        public bool DeleteBasketRecord(int basketRecordId)
        {
            IBasketRecordRepository basketRecordRepository = new BasketRecordRepository(_db);
            return basketRecordRepository.DeleteBasketRecord(basketRecordId);            
        }


    }
}
