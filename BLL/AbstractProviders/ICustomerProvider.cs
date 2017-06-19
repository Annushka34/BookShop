using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using BLL.ViewModels;

namespace BLL.AbstractProviders
{
    public interface ICustomerProvider
    {
        bool AddBasketRecord(BasksetRecordViewModel basketRecordViewModel);
        bool CreateOrderList(int customerId);
        bool DeleteBasketRecord(int basketRecordId);
    }
}
