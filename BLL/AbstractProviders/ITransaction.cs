using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AbstractProviders
{
    public interface ITransaction: IDisposable
    {
        void TransactionStart();
        void TransactionCommit();
    }
}
