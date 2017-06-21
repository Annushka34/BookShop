using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using BLL.ViewModels;

namespace BLL.AbstractProviders
{
    public interface ICategoryProvider
    {
        bool CreateNewCategory(CategoryViewModel categoryModel);
        List<CategoryUIModel> GetAllCategoriesNames();
    }
}
