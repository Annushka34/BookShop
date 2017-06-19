using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace DAL.AbstractRepository
{
    public interface IBasketRecordRepository
    {
        BasketRecord CreateBasketRecord(BasketRecord basketRecord);
        bool DeleteBasketRecord(BasketRecord basketRecord);
        bool Update(BasketRecord basketRecordOld, BasketRecord basketRecordNew);//реалызувати чере сщзн


        #region Get
        BasketRecord GetBasketRecordById(int basketRecordId);
        List<BasketRecord> GetBasketRecordsByBasket(Basket basket);
        List<BasketRecord> GetBasketRecordsByCustomer(Customer сustomer);
        #endregion
      
    }
}
