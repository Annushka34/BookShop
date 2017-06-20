using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace DAL.AbstractRepository
{
    public interface IPublishRepository
    {
        #region CRUD
        Publish CreatePublish(Publish publish);
        bool DeletePublish(int publishId);
        #endregion

        #region Get
        Publish GetPublishById(int publishId);
        #endregion
    }
}
