using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entity
{
    public class MyContext: DbContext
    {
        public MyContext() : base("MyDbConnection")
        {
            Database.SetInitializer<MyContext>(null);
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketRecord> BasketRecords { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderRecord> OrderRecords { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Publish> Publishes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Review> Reviews { get; set; }

    }
}
