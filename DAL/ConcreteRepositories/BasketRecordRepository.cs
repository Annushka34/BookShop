using DAL.AbstractRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace DAL.ConcreteRepositories
{
    public class BasketRecordRepository : IBasketRecordRepository
    {
        MyContext _db;
        public BasketRecordRepository(MyContext db)
        {
            _db = db;
        }
        #region CRUD
        public BasketRecord CreateBasketRecord(BasketRecord basketRecord)
        {
            _db.BasketRecords.Add(basketRecord);
            _db.SaveChanges();
            return basketRecord;
        }

        public bool DeleteBasketRecord(BasketRecord basketRecord)
        {
            try
            {
                _db.BasketRecords.Remove(basketRecord);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(BasketRecord basketRecordOld, BasketRecord basketRecordNew)
        {
            try
            {
                basketRecordOld.Count = basketRecordNew.Count;
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
        public List<BasketRecord> GetBasketRecordsByBasket(Basket basket)
        {
            List<BasketRecord> basketRecords = _db.BasketRecords.Where(x => x.Basket == basket).ToList();
            return basketRecords;
        }

        public List<BasketRecord> GetBasketRecordsByCustomer(Customer сustomer)
        {
            List<BasketRecord> basketRecords = _db.BasketRecords.Where(x => x.Basket.Customer == сustomer).ToList();
            return basketRecords;
        }

        public BasketRecord GetBasketRecordById(int basketRecordId)
        {
            BasketRecord basketRecord = _db.BasketRecords.SingleOrDefault(x => x.Id == basketRecordId);
            return basketRecord;
        }
        #endregion
    }
}
