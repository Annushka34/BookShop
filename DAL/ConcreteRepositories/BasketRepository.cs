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
        #region CRUD
        public Basket CreateBasket(Customer customer)
        {
            Basket basket = new Basket();
            basket.Customer = customer;
            //basket.TimePurchase = DateTime.Now;
            _db.Baskets.Add(basket);
            _db.SaveChanges();
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

        public bool ClearBasket(int basketId)
        {
            try
            {
                Basket basket = _db.Baskets.SingleOrDefault(x => x.CustomerId == basketId);
                foreach (var rec in basket.BasketRecords)
                {
                    basket.BasketRecords.Remove(rec);
                }
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region GET
        public Basket GetBasketById(int customerId)
        {
            Basket basket = _db.Baskets.SingleOrDefault(x => x.CustomerId == customerId);
            return basket;
        }
        #endregion
    }
}
