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
        #region CRUD
        Basket CreateBasket(Customer customer);
        bool DeleteBasket(int basketId);
        bool ClearBasket(int basketId);
        #endregion

        #region GET
        Basket GetBasketById(int customerId);
        List<BasketRecord> GetBasketRecordsByBasket(Basket basket);
        BasketRecord GetBasketRecordByBook(int bookId, int basketId);
        #endregion
    }
}
