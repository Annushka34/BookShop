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
        bool IsCustomer(int userId);
        bool CreateCustomer(User user);
    }
}
