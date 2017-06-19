using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.AbstractRepository;
using DAL.Entity;

namespace DAL.ConcreteRepositories
{
    class PublishRepository:IPublishRepository
    {
        MyContext _db;
        public PublishRepository(MyContext db)
        {
            _db = db;
        }
        #region CRUD
        public Publish CreatePublish(Publish publish)
        {
            _db.Publishes.Add(publish);
            _db.SaveChanges();
            return publish;
        }
        public bool DeletePublish(int publishId)
        {
            try
            {
                Publish publish = _db.Publishes.SingleOrDefault(x => x.Id == publishId);
                _db.Publishes.Remove(publish);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Get
        public Publish GetPublishById(int publishId)
        {
            Publish publish = _db.Publishes.SingleOrDefault(x => x.Id == publishId);
            return publish;
        }
        #endregion
    }
}
