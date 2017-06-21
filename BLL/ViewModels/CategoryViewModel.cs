using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Permissions;
using System.Text;

namespace BLL.ViewModels
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            BooksId=new List<int>();
        }
        public string CategoryName { get; set; }
        public List<int> BooksId { get; set; }
    }
}
