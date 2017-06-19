using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace DAL.AbstractRepository
{
    public interface IPictureRepository
    {
        #region CRUD
        Picture CreatePicture(Picture picture);
        bool DeletePicture(int bookId);
        #endregion

        #region Get
        
        Picture GetPictureByBookId(int bookId);
        #endregion
    }
}
