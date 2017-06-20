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
            PicturePath = book.Picture.PicturePath;
            PublishId = book.PublishId;

            Authors = new List<AuthorUIModel>();
            Tags = new List<TagUIModel>();
            Categories = new List<CategoryUIModel>();
            Reviews = new List<ReviewUIModel>();
        }
        public int Isbn { get; set; }
        public int PublishId { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PicturePath { get; set; }

        public List<AuthorUIModel> Authors { get; set; }
        public List<TagUIModel> Tags { get; set; }
        public List<CategoryUIModel> Categories { get; set; }
        public List<ReviewUIModel> Reviews { get; set; }
        
    }
}
