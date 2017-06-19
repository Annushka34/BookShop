using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace DAL.AbstractRepository
{
    public interface ITagRepository
    {
        Tag CreateTag(Tag tag);
        bool DeleteTag(int tagId);


        #region Get
        Tag GetTagById(int tagId);
        #endregion
    }
}
