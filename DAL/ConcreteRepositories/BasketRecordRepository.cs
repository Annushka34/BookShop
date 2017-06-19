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

        public bool DeleteBasketRecord(int basketRecordId)
        {
            var basketRecord = GetBasketRecordById(basketRecordId);
            if (basketRecord == null)
                return false;
            _db.BasketRecords.Remove(basketRecord);
            _db.SaveChanges();
            return true;
        }

        public BasketRecord Update(BasketRecord basketRecordOld, BasketRecord basketRecordNew)
        {
            basketRecordOld.Count = basketRecordNew.Count;
            _db.SaveChanges();
            return basketRecordOld;
        }
        #endregion

        #region GET
        public BasketRecord GetBasketRecordById(int basketRecordId)
        {
            BasketRecord basketRecord = _db.BasketRecords.SingleOrDefault(x => x.Id == basketRecordId);
            return basketRecord;
        }
        #endregion
    }
}
