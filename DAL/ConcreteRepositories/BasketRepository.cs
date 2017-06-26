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
            _db.Baskets.Add(basket);
            _db.SaveChanges();
            return basket;
        }
        public bool DeleteBasket(int basketId)
        {
            Basket basket = GetBasketById(basketId);
            if (basket == null)
            {
                return false;
            }
            _db.Baskets.Remove(basket);
            _db.SaveChanges();
            return true;
        }

        public Basket ClearBasket(int basketId)
        {
            Basket basket = GetBasketById(basketId);
            if (basket == null)
            {
                return null;
            }
            foreach (var record in basket.BasketRecords)
            {
                basket.BasketRecords.Remove(record);
            }
            _db.SaveChanges();
            return basket;
        }
        #endregion

        #region GET
        public Basket GetBasketById(int customerId)
        {
            Basket basket = _db.Baskets.SingleOrDefault(x => x.CustomerId == customerId);
            return basket;
        }
        public List<BasketRecord> GetBasketRecordsByBasket(int basketId)
        {
            List<BasketRecord> basketRecords = _db.BasketRecords.Where(x => x.BasketId == basketId).ToList();
            return basketRecords;
        }

        public BasketRecord GetBasketRecordByBook(int bookId, int basketId)
        {
            Basket basket = GetBasketById(basketId);
            if (basket == null)
                return null;

            var basketRecords = GetBasketRecordsByBasket(basket.CustomerId);
            if (basketRecords.Count == 0)
                return null;

            BasketRecord basketRecord = basketRecords.SingleOrDefault(x => x.BookId == bookId);
            return basketRecord;
        }

        #endregion
    }
}
