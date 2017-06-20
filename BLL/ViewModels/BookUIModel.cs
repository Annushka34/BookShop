using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels
{
    public class BookUIModel
    {
        public BookUIModel(Book book)
        {
            Isbn = book.Isbn;
            Price = book.Price;
            Name = book.Name;
            Description = book.Description;
            Authors = book.Authors.ToList();
            Tags = book.Tags.ToList();
            Categories = book.Categories.ToList();
            Reviews = book.Reviews.ToList();
            Picture = book.Picture;
            Publish = book.Publish;
        }
        public int Isbn { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Author> Authors { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Category> Categories { get; set; }
        public List<Review> Reviews { get; set; }
        public Picture Picture { get; set; }
        public Publish Publish { get; set; }
    }
}
