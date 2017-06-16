using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.AbstractRepository
{
    public interface IBasketRepository
    {
        Basket CreateBasket(Customer customer);
        bool DeleteBasket(int basketId);
        bool ClearBasketForCustomer(Customer customer);


        #region BascketRecord
        bool DeleteBasketRecordForBasket(int basketRecordId, Basket basket);
        Basket AddBasketRecordForBasket(BasketRecord basketRecord, Basket basket);
        #endregion


        #region Get
        Basket GetBasketByCustomer(Customer customer);
        DateTime GetTimeBasket(Customer customer);
        #endregion
    }
}
