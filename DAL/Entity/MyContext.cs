﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class MyContext: DbContext
    {
        public MyContext() : base("MyDbConnection")
        {
            Database.SetInitializer<MyContext>(null);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Book> Books { get; set; }
    }
}
