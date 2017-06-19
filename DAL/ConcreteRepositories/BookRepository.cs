using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DAL.AbstractRepository;
using DAL.Entity;

namespace DAL.ConcreteRepositories
{
    class BookRepository : IBookRepository
    {
        private MyContext _db;

        public BookRepository(MyContext db)
        {
            _db = db;
        }
        #region CRUD
        public Book CreateBook(Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
            return book;
        }

        public bool DeleteBook(int bookId)
        {
            try
            {
                Book book = _db.Books.SingleOrDefault(x => x.Id == bookId);
                _db.Books.Remove(book);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(Book bookOld, Book bookrNew)
        {
            try
            {
                bookOld.Name = bookrNew.Name;
                bookOld.Isbn = bookrNew.Isbn;
                bookOld.Picture = bookrNew.Picture;
                bookOld.Publish = bookrNew.Publish;
                bookOld.Authors = bookrNew.Authors;
                bookOld.Categories = bookrNew.Categories;
                bookOld.Reviews = bookrNew.Reviews;
                bookOld.OrderRecords = bookrNew.OrderRecords;
                bookOld.BasketRecords = bookrNew.BasketRecords;
                bookOld.Description = bookrNew.Description;
                bookOld.Price = bookrNew.Price;
                bookOld.Tags = bookrNew.Tags;
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region GET
        public Book GetBookById(int bookId)
        {
            Book book = _db.Books.SingleOrDefault(u => u.Id == bookId);
            return book;
        }

        public List<Book> GetBooksByAuthor(Author author)
        {
            List<Book> books = _db.Authors.Where(x => x.Id == author.Id).SelectMany(x=>x.Books).ToList();
            return books;
        }

        public List<Book> GetBooksByCategory(Category category)
        {
            List<Book> books = _db.Categories.Where(x => x.Id == category.Id).SelectMany(x => x.Books).ToList();
            return books;
        }

        public List<Book> GetBooksByCustomer(Customer customer)
        {
            var orders = _db.OrderRecords.Where(x => x.Order.Customer == customer);
            List<Book> booksByCustomer = orders.Select(x=>x.Book).ToList();
            return booksByCustomer;
        }

        public List<Book> GetBooksByTags(Tag tag)
        {
            List<Book> books = _db.Books.Where(x => x.Tags.Contains(tag)).ToList();
            return books;
        }
        #endregion
    }
}

