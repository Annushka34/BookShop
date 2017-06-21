
using System.Collections.Generic;
using DAL.Entity;

namespace BLL.ViewModels
{
    public class CategoryUIModel
    {
        public CategoryUIModel(Category category)//список категорій на юай
        {
            Id = category.Id;
            Name = category.Name;
        }
     
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CategoryViewModel//приходить з юай при створенні нової категорї
    {
        public CategoryViewModel()
        {
            BooksId = new List<int>();
        }
        public string CategoryName { get; set; }
        public List<int> BooksId { get; set; }
    }
}
