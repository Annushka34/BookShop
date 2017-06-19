using DAL.AbstractRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace DAL.ConcreteRepositories
{
    public class CustomerRepository : ICustomerRepository
    {
        MyContext _db;
        public CustomerRepository(MyContext db)
        {
            _db = db;
        }

        #region CRUD
        public Customer CreateCustomer(User user)
        {
            Customer customer = new Customer();
            customer.User = user;
            _db.Customers.Add(customer);
            _db.SaveChanges();
            return customer;
        }
        public bool DeleteCustomer(int userId)
        {
            Customer customer = GetCustomerById(userId);
            if (customer == null)
            {
                return false;
            }
            _db.Customers.Remove(customer); //??
            _db.SaveChanges();
            return true;
        }
        #endregion

        #region GET
        public Customer GetCustomerById(int userId)
        {
            var customer = _db.Customers.SingleOrDefault(u => u.UserId == userId);
            return customer;
        }
        #endregion
    }
}
