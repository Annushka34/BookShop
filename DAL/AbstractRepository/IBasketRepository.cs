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
        bool IsCreated(int customerId);
        DateTime GetTimePurchase(int customerId);
        bool CreateBasket(Customer customer);
    }
}
