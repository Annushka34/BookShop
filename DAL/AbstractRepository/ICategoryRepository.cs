using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace DAL.AbstractRepository
{
    public interface ICategoryRepository
    {
        #region CRUD
        Category CreateCategory(Category category);
        bool DeleteCategory(Category category);
        bool Update(int oldCategoryId, Category categoryNew);
        #endregion

        #region Get
        Category GetCategoryById(int categoryId);
        #endregion
    }
}
