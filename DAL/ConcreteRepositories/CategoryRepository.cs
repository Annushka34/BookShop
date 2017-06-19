﻿using DAL.AbstractRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace DAL.ConcreteRepositories
{
    public class CategoryRepository : ICategoryRepository
    {
        MyContext _db;
        public CategoryRepository(MyContext db)
        {
            _db = db;
        }

        #region CRUD
        public Category CreateCategory(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
            return category;
        }

        public bool DeleteCategory(Category category)
        {
            try
            {
                _db.Categories.Remove(category);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Category categoryOld, Category categoryNew)
        {
            try
            {
                categoryOld.Name = categoryNew.Name;
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
        public Category GetCategoryById(int categoryId)
        {
            Category category = _db.Categories.SingleOrDefault(x => x.Id == categoryId);
            return category;
        }
        #endregion
    }
}
