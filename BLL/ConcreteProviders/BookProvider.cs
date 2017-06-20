using BLL.AbstractProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.ViewModels;
using DAL.Entity;
using DAL.AbstractRepository;
using DAL.ConcreteRepositories;

namespace BLL.ConcreteProviders
{
    public class BookProvider : IBookProvider
    {
        MyContext _db;
        public BookProvider(MyContext db)
        {
            _db = db;
        }
        public BookUIModel CreateBook(BookCreateViewModel book)
        {
            IBookRepository bookRepository = new BookRepository(_db);

            Book newBook = bookRepository.GetBookByName(book.Name);
            if(newBook != null)
            {
                return null;
            }

            newBook = new Book();
            newBook.Isbn = book.Isbn;
            newBook.Name = book.Name;
            newBook.Description = book.Description;
            newBook.Price = book.Price;

            //дописати-переробити
            newBook.Publish = book.Publish;
            newBook.Categories = book.Categories;
            newBook.Authors = book.Authors;
            newBook.Picture = book.Picture;
            ///////////////////////////////
            newBook = bookRepository.CreateBook(newBook);  ///???????????????????????
            BookUIModel bookUIModel = new BookUIModel(newBook);
            return bookUIModel;
        }

        public BookCreateUIModel GetCreateUIModel()
        {
            IPublishRepository publishRepository = new PublishRepository(_db);
            ICategoryRepository categoryRepository = new CategoryRepository(_db);
            ITagRepository tagRepository = new TagRepository(_db);
            IAuthorRepository authorRepository = new AuthorRepository(_db);

            BookCreateUIModel createUIModel = new BookCreateUIModel();
            createUIModel.Publishes = publishRepository.GetAllPublishes();
            createUIModel.Categories = categoryRepository.GetAllCategories();
            createUIModel.Tags = tagRepository.GetAllTags();
            createUIModel.Authors = authorRepository.GetAllAuthors();
            return createUIModel;
        }
    }
}
