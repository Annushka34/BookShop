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
        MyContext _db;
        public CustomerRepository(MyContext db)
        {
            _db = db;
        }

        public Customer CreateCustomer(User user)
        {
            Customer customer = new Customer();
            customer.User = user;
            _db.Customers.Add(customer);
            _db.SaveChanges();
            return customer;
        }

        public Customer GetCustomerById(int userId)
        {
            var customer = _db.Customers.SingleOrDefault(u => u.UserId == userId);
            return customer;
        }

        public bool DeleteCustomer(int userId)
        {
            Customer customer = _db.Customers.SingleOrDefault(x => x.UserId == userId);
            try
            {
                _db.Customers.Remove(customer); //??
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }
    }
}
