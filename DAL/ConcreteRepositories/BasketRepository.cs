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
        private MyContext db;
        public bool CreateBasket(Customer customer)
        {
            throw new NotImplementedException();
        }

        public DateTime GetTimePurchase(int customerId)
        {
            throw new NotImplementedException();
        }

        public bool IsCreated(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
