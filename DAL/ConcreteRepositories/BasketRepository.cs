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

        public bool DeleteBasket(Basket basket)
        {
            try
            {
                _db.Baskets.Remove(basket);   
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
