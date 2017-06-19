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
    class CustomerProvider:ICustomerProvider
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

            Customer customer = customerRepository.GetCustomerById(basketRecordViewModel.customerId);
            if (customer == null)
            {
                return false;
            }
            BasketRecord basketRecord = basketRepository.GetBasketRecordByBook(basketRecordViewModel.BookId, basketRecordViewModel.customerId);
            BasketRecord basketRecordNew = new BasketRecord();
            basketRecordNew.BasketId = basketRecordViewModel.customerId;
            basketRecordNew.BookId = basketRecordViewModel.BookId;
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
                basketRecordRepository.CreateBasketRecord(basketRecord);
            }
            return true;
        }
        
        public bool CreateOrderList(int customerId)
        {
            ICustomerRepository customerRepository = new CustomerRepository(_db);
            IBasketRepository basketRepository=new BasketRepository(_db);
            IBasketRecordRepository basketRecordRepository = new BasketRecordRepository(_db);
            IOrderRepository orderRepository=new OrderRepository(_db);
            IOrderRecordsRepository orderRecordsRepository=new OrderRecordRepository(_db);
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

                    var bascketRecords = basketRepository.GetBasketRecordsByBasket(customer.Basket);//всі поля з кошика
                    Order order = orderRepository.CreateOrder(customer);//створли нове замовлення

                    foreach (var records in bascketRecords)
                    {
                        OrderRecord orderRec = new OrderRecord();//нове поле замовлення
                        orderRec.BookId = records.BookId;
                        orderRec.Order = order;
                        orderRec.Count = records.Count;
                        orderRecordsRepository.CreateOrderRecord(orderRec);//додали до Order
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
