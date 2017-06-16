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
        Category CreateCategory(Category category);
        bool DeleteCategory(Category category);
        bool Update(Category categoryOld, Category categoryNew);


        #region Get
        Category GetCategoryById(int categoryId);
        #endregion
    }
}
