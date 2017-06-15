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
        Basket GetBasketById(int customerId);
        Basket CreateBasket(Customer customer);
        bool DeleteBasket(Basket basket);
    }
}
