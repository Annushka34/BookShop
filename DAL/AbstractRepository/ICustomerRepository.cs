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
        Customer CreateCustomer(User user);
        bool DeleteCustomer(int customerId);

        #region  Get
        Customer GetCustomerById(int userId);

        #endregion

    }
}
