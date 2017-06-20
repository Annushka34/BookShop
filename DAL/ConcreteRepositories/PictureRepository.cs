using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.AbstractRepository;
using DAL.Entity;

namespace DAL.ConcreteRepositories
{
    class PictureRepository : IPictureRepository
    {
        MyContext _db;
        public PictureRepository(MyContext db)
        {
            _db = db;
        }
        #region CRUD
        public Picture CreatePicture(Picture picture)
        {
            _db.Pictures.Add(picture);
            _db.SaveChanges();
            return picture;
        }

        public bool DeletePicture(int bookId)
        {
            Picture picture = GetPictureByBookId(bookId);
            if (picture == null)
            {
                return false;
            }
            _db.Pictures.Remove(picture);
            _db.SaveChanges();
            return true;
        }
        #endregion

        #region Get
        public Picture GetPictureByBookId(int bookId)
        {
            Picture picture = _db.Pictures.SingleOrDefault(x => x.BookId == bookId);
            return picture;
        }
        #endregion
    }
}
