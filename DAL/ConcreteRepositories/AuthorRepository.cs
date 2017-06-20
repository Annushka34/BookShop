using DAL.AbstractRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace DAL.ConcreteRepositories
{
    public class AuthorRepository : IAuthorRepository
    {
        MyContext _db;
        public AuthorRepository(MyContext db)
        {
            _db = db;
        }
        #region CRUD
        public Author CreateAuthor(Author author)
        {
            _db.Authors.Add(author);
            _db.SaveChanges();
            return author;
        }

        public bool DeleteAuthor(int authorId)
        {
            Author author = GetAuthorById(authorId);
            if (author == null)
            {
                return false;
            }
            _db.Authors.Remove(author);
            _db.SaveChanges();
            return true;
        }
        public Author Update(Author authorOld, Author authorNew)
        {
            authorOld.FirstName = authorNew.FirstName;
            authorOld.LastName = authorNew.LastName;
            _db.SaveChanges();
            return authorOld;
        }
        #endregion

        #region GET
        public Author GetAuthorById(int authorId)
        {
            Author author = _db.Authors.SingleOrDefault(x => x.Id == authorId);
            return author;
        }
        public List<Author> GetAllAuthors()
        {
            return _db.Authors.ToList();
        }
        #endregion
    }
}
