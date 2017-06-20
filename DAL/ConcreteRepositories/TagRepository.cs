using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.AbstractRepository;
using DAL.Entity;

namespace DAL.ConcreteRepositories
{
    public class TagRepository : ITagRepository
    {
        MyContext _db;
        public TagRepository(MyContext db)
        {
            _db = db;
        }
        #region CRUD
        public Tag CreateTag(Tag tag)
        {
            _db.Tags.Add(tag);
            _db.SaveChanges();
            return tag;
        }
        public bool DeleteTag(int tagId)
        {
            Tag tag = GetTagById(tagId);
            if (tag == null)
            {
                return false;
            }
            _db.Tags.Remove(tag);
            _db.SaveChanges();
            return true;
        }
        #endregion

        #region Get
        public Tag GetTagById(int tagId)
        {
            Tag tag = _db.Tags.SingleOrDefault(x => x.Id == tagId);
            return tag;
        }
        #endregion
    }
}
