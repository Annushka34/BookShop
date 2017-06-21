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
        public BookUIModelWithCollections CreateBook(BookCreateViewModel book)
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
                    newBook.PublishId = book.PublishId;
                    

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


                    bookRepository.CreateBook(newBook); //створили нову книжку з коллекціями

                    BookUIModelWithCollections bookUiModelWithCollections = new BookUIModelWithCollections(newBook);//створили модельку для повернення на юай книжки з коллекцыями

                    transaction.TransactionCommit();
                    return bookUiModelWithCollections;
                }
                catch
                {
                    transaction.Dispose();
                    return null;
                }
            }
        } 
    }
}
