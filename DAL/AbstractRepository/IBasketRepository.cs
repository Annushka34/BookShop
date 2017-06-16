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
        Basket CreateBasket(Customer customer,Basket basket);
        bool UpdateBasket(Basket basketOld, Basket basketNew);
        bool DeleteBasketForCustomer(Customer customer);
        bool ClearBasketForCustomer(Customer customer);


        #region BascketRecord
        bool DeleteBasketRecordForBasket(int basketRecordId, Basket basket);
        Basket AddBasketRecordForBasket(BasketRecord basketRecord, Basket basket);
        #endregion


        #region Get
        Basket GetBasketById(int busketId);
        Basket GetBasketByCustomer(Customer customer);
        DateTime GetTimeBasket(Customer customer);
        #endregion
        Basket GetBasketById(int customerId);
        Basket CreateBasket(Customer customer);
        bool DeleteBasket(Basket basket);
    }
}
