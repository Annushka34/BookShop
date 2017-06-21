using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels
{
    public class CategoryUIModel
    {
        public CategoryUIModel(CategoryUIModel category)
        {
            Id = category.Id;
            Name = category.Name;
            Books = new List<BookUIModel>();
        }
        public CategoryUIModel()
        {
            Books = new List<BookUIModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookUIModel> Books { get; set; }
    }
}
