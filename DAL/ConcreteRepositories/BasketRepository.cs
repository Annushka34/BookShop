using DAL.AbstractRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace DAL.ConcreteRepositories
{
    public class BasketRepository : IBasketRepository
    {
        MyContext _db;
        public BasketRepository(MyContext db)
        {
            _db = db;
        }
        public Basket CreateBasket(Customer customer)
        {
            Basket basket = new Basket();
            basket.Customer = customer;
            basket.TimePurchase = DateTime.Now;
            _db.Baskets.Add(basket);
            _db.SaveChanges();
            return basket;
        }

        public Basket GetBasketById(int customerId)
        {
            Basket basket = _db.Baskets.SingleOrDefault(x => x.CustomerId == customerId);
            return basket;
        }

        public bool DeleteBasket(int basketId)
        {
            try
            {
                Basket basket = _db.Baskets.SingleOrDefault(x => x.CustomerId == basketId);
                _db.Baskets.Remove(basket);   
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ClearBasketForCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool DeleteBasketRecordForBasket(int basketRecordId, Basket basket)
        {
            throw new NotImplementedException();
        }

        public Basket AddBasketRecordForBasket(BasketRecord basketRecord, Basket basket)
        {
            throw new NotImplementedException();
        }

        public Basket GetBasketByCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public DateTime GetTimeBasket(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
