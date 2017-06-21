using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using BLL.AbstractProviders;
using BLL.ViewModels;
using DAL.AbstractRepository;
using DAL.ConcreteRepositories;
using DAL.Entity;

namespace BLL.ConcreteProviders
{
    public class CategoryProvider : ICategoryProvider
    {
        private MyContext _db;

        public CategoryProvider()
        {
                _db=new MyContext();
        }
        public bool CreateNewCategory(CategoryViewModel categoryModel)
        {
            ICategoryRepository categoryRepository = new CategoryRepository(_db);
            IBookRepository bookRepository = new BookRepository(_db);
            Category category = new Category();
            category.Name = categoryModel.CategoryName;
            categoryRepository.CreateCategory(category);
            _db.SaveChanges();
            if (categoryModel.BooksId.Count != 0)
            {
                foreach (var id in categoryModel.BooksId)
                {
                    Book book = bookRepository.GetBookById(id);
                    book.Categories.Add(category);
                }
                _db.SaveChanges();
            }
            return true;
        }

        public List<CategoryUIModel> GetAllCategoriesNames()
        {
            ICategoryRepository userRepository = new CategoryRepository(_db);

            List<CategoryUIModel> categories = new List<CategoryUIModel>();

            foreach (var category in _db.Categories)
            {
                CategoryUIModel newCategory = new CategoryUIModel(category);
                categories.Add(newCategory);
            }
            return categories;
        }
    }
}
