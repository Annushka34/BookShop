using DAL.AbstractRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace DAL.ConcreteRepositories
{
    public  class CustomerRepository : ICustomerRepository
    {
        private MyContext db;
        public bool CreateCustomer(User user)
        {
            db = new MyContext();
            Customer customer = new Customer();
            customer.UserId = user.Id;
            db.Customers.Add(customer);
            db.SaveChanges();
            return true;
            
        }

        public bool IsCustomer(int userId)
        {
            db = new MyContext();
            var customer = db.Customers.Find(userId);
            if (customer != null)
                return true;
            else
                return false;
        }
    }
}
