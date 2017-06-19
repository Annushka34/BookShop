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
        Book Update(Book bookOld, Book bookrNew);


        #region Get
        Book GetBookById(int bookId);
        List<Book> GetBooksByCategory(int categoryId);
        List<Book> GetBooksByAuthor(int authorId);
        List<Book> GetBooksByCustomer(Customer customer);
        List<Book> GetBooksByTags(Tag tag);
        #endregion
    }
}
