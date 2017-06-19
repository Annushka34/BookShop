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

        public bool DeleteAuthor(Author author)
        {
            try
            {
                _db.Authors.Remove(author);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(Author authorOld, Author authorNew)
        {
            try
            {
                authorOld.FirstName = authorNew.FirstName;
                authorOld.LastName = authorNew.LastName;
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
        public Author GetAuthorById(int authorId)
        {
            Author author = _db.Authors.SingleOrDefault(x => x.Id == authorId);
            return author;
        }
        #endregion
    }
}
