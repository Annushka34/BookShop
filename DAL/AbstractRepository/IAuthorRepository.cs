using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace DAL.AbstractRepository
{
    public interface IAuthorRepository
    {
        #region CRUD
        Author CreateAuthor(Author author);
        bool DeleteAuthor(int authorId);
        Author Update(Author authorOld, Author authorNew);
        #endregion

        #region Get
        Author GetAuthorById(int authorId);
        List<Author> GetAllAuthors();
        #endregion
    }
}
