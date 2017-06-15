using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.AbstractRepository
{
    public interface ICustomerRepository
    {
        Customer GetCustomerById(int userId);
        Customer CreateCustomer(User user);
    }
}
