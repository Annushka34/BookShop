using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace DAL.AbstractRepository
{
    public interface IBookRepository
    {
        Book CreateBook(Book book);
        bool DeleteBook(int bookId);
        bool Update(Book bookOld, Book bookrNew);


        #region Get
        Book GetBookById(int bookId);
        IQueryable GetBooksByCategory(Category category);
        IQueryable <Book> GetBooksByAuthor(Author author);
        IQueryable <Book> GetBooksByCustomer(Customer customer);
        IQueryable <Book> GetBooksByTags(Tag tag);
        #endregion
    }
}
