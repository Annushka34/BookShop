using BLL.AbstractProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL.ConcreteProviders
{
    public class Transaction : ITransaction
    {
        TransactionScope _transaction;

        public void TransactionCommit()
        {
            _transaction.Complete();
        }

        public void TransactionStart()
        {
            _transaction = new TransactionScope();
        }

        public void Dispose()
        {
            if(_transaction!=null)
                _transaction.Dispose();
        }
    }
}
