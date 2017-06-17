﻿using DAL.Entity;
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
        #endregion

        #region GET
        Basket GetBasketById(int customerId);
        #endregion
    }
}
