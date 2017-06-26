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
using System.Data.Entity;
using System.Collections.ObjectModel;

namespace BLL.ConcreteProviders
{
    public class BookProvider : IBookProvider
    {
        MyContext _db;
        public BookProvider()
        {
            _db = new MyContext();
        }
        public BookUIModel CreateBook(BookCreateViewModel book)//створити книжку - від юай приходить книжка з колекціями айдішок. На юайку іде назва книжки з новою айдішкою
        {
            IBookRepository bookRepository = new BookRepository(_db);
            IAuthorRepository authorRepository=new AuthorRepository(_db);
            ICategoryRepository categoryRepository=new CategoryRepository(_db);
            ITagRepository tagRepository=new TagRepository(_db);
            IPictureRepository pictureRepository=new PictureRepository(_db);
            Book newBook = bookRepository.GetBookByName(book.Name);
            if(newBook != null)
            {
                return null;
            }
            using (Transaction transaction = new Transaction())
            {
                try
                {
                    transaction.TransactionStart();
                    newBook = new Book();
                    newBook.Isbn = book.Isbn;
                    newBook.Name = book.Name;
                    newBook.Description = book.Description;
                    newBook.Price = book.Price;
                    newBook.Rank = 0;
                    newBook.PublishId = book.PublishId;
                    
                    bookRepository.CreateBook(newBook); //створили нову книжку з коллекціями

                    if (book.AuthorsIdList.Count != 0)//привязали коллекцію авторів
                    {
                        foreach (var authorId in book.AuthorsIdList)
                        {
                            newBook.Authors.Add(authorRepository.GetAuthorById(authorId));
                        }
                    }
                    if (book.CategoriesIdList.Count != 0)//привязали коллекцію категорій
                    {
                        foreach (var categoriId in book.CategoriesIdList)
                        {
                            newBook.Categories.Add(categoryRepository.GetCategoryById(categoriId));
                        }
                    }
                    if (book.TagsIdList.Count != 0)//привязали коллекцію тегів
                    {
                        foreach (var tagId in book.TagsIdList)
                        {
                            newBook.Tags.Add(tagRepository.GetTagById(tagId));
                        }
                    }
                    ///////////////////////////////

                    Picture picture = new Picture();//створили нову картинку
                    picture.Book = newBook;
                    picture.PicturePath = book.PicturePath;
                    pictureRepository.CreatePicture(picture);

                    newBook.Picture = picture;//додали картинку до новоъ книжки

                    _db.SaveChanges();//так як багато операцій створюється в провайдері то він сам звертається до бази даних

                    BookUIModel bookUiModel = new BookUIModel(newBook);//створили модельку для повернення на юай книжки з коллекцыями

                    transaction.TransactionCommit();
                    return bookUiModel;
                }
                catch
                {
                    transaction.Dispose();
                    return null;
                }
            }
        }

        public List<BookUIModel> GetAllBooks()
        {
            List<BookUIModel> books = new List<BookUIModel>();
            IPictureRepository pictureRepository = new PictureRepository(_db);
            foreach (var book in _db.Books.ToList())
            {
                BookUIModel newBook = new BookUIModel(book);
                newBook.PicturePath = pictureRepository.GetPictureByBookId(book.Id).PicturePath;
                books.Add(newBook);
            }
            return books;
        }

        //public List<BookUIShortModel> GetAllBooksShortInfo()
        //{
        //    List<BookUIShortModel> books = new List<BookUIShortModel>();
        //    PictureRepository pictureRepository = new PictureRepository(_db);
        //    foreach (var book in _db.Books.Include(x=>x.Authors).Include(x=> x.Picture))
        //    {
        //        BookUIShortModel newBook = new BookUIShortModel(book);
        //        foreach(var author in book.Authors)
        //        {
        //            newBook.BookAuthorName += author.FirstName + " " + author.LastName + "\n";
        //        }
        //        //newBook.BookImagePath = pictureRepository.GetPictureByBookId(book.Id).PicturePath;
        //        newBook.BookImagePath = book.Picture.PicturePath;
        //        books.Add(newBook);
                
        //    }
        //    return books;
        //}

        public ObservableCollection<BookUIShortModel> GetAllBooksShortInfo()
        {
            ObservableCollection<BookUIShortModel> books = new ObservableCollection<BookUIShortModel>();
            PictureRepository pictureRepository = new PictureRepository(_db);
            foreach (var book in _db.Books.Include(x => x.Authors).Include(x => x.Picture))
            {
                BookUIShortModel newBook = new BookUIShortModel(book);
                foreach (var author in book.Authors)
                {
                    newBook.BookAuthorName += author.FirstName + " " + author.LastName + "\n";
                }
                //newBook.BookImagePath = pictureRepository.GetPictureByBookId(book.Id).PicturePath;
                newBook.BookImagePath = book.Picture.PicturePath;
                books.Add(newBook);

            }
            return books;
        }

        public ObservableCollection<BookUIShortModel> SearchBooks(SearchViewModel searchModel)
        {
            ObservableCollection<BookUIShortModel> books = new ObservableCollection<BookUIShortModel>();
            IQueryable <Book>filter = _db.Books;
            if(searchModel.CategoryId != -1)
            {
                filter = filter.Where(x => x.Categories.Any(c => c.Id.Equals(searchModel.CategoryId)));
            }
            if (searchModel.AuthorId != -1)
            {
                filter = filter.Where(x => x.Authors.Any(c => c.Id.Equals(searchModel.AuthorId)));
            }
            if (searchModel.PublishId != -1)
            {
                filter = filter.Where(x => x.PublishId == searchModel.PublishId);
            }
            if (searchModel.TagId != -1)
            {
                filter = filter.Where(x => x.Tags.Any(c => c.Id.Equals(searchModel.TagId)));
            }
            if (searchModel.BookName != "")
            {
                filter = filter.Where(x => x.Name.Contains(searchModel.BookName));
            }
            List<Book> templist = filter.ToList();
            foreach (var item in templist)
            {
                BookUIShortModel newBook = new BookUIShortModel(item);
                foreach (var author in item.Authors)
                {
                    newBook.BookAuthorName += author.FirstName + " " + author.LastName + "\n";
                }
                //newBook.BookImagePath = pictureRepository.GetPictureByBookId(book.Id).PicturePath;
                newBook.BookImagePath = item.Picture.PicturePath;
                books.Add(newBook);
            }
            return books;
        }

    }
}
