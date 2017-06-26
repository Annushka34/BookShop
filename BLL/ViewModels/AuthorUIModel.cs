using DAL.Entity;
using System.Collections.Generic;

namespace BLL.ViewModels
{
    public class AuthorUIModel
    {
        public AuthorUIModel(Author author) //список авторів на юай
        {
            Id = author.Id;
            AuthorName = author.FirstName + " " + author.LastName;
        }

        public int Id { get; set; }
        public string AuthorName { get; set; }
    }

    public class AuthorViewModel//приходить з юай при створенні нового автора
    {
        public AuthorViewModel()
        {
            BooksId = new List<int>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<int> BooksId { get; set; }
    }

    public class AuthorUIModelWithBooks//список авторів на юай з книжками
    {
        public AuthorUIModelWithBooks(Author author)
        {
            Id = author.Id;
            FirstName = author.FirstName;
            LastName = author.LastName;
            Books = new List<BookUIModel>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<BookUIModel> Books { get; set; }
    }
}