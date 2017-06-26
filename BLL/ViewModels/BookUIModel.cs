using DAL.Entity;
using System.Collections.Generic;

namespace BLL.ViewModels
{

    
    public class BookUIModel//список книжок на юай
    {
        public BookUIModel(Book book)
        {
            Isbn = book.Isbn;
            Price = book.Price;
            Name = book.Name;
            Description = book.Description;
            //PicturePath = book.Picture.PicturePath;
            PublishId = book.PublishId;
            Rank = book.Rank;
        }
        public int Isbn { get; set; }
        public int PublishId { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PicturePath { get; set; }
        public double Rank { get; set; }
    }

    public class BookUIShortModel//список книжок на юай
    {
        public BookUIShortModel(Book book)
        {
            BookId = book.Id;
            BookPrice = book.Price;
            BookName = book.Name;
            BookDescription = book.Description;
            BookRank = book.Rank;
        }

        public int BookId { get; set; }
        public double BookPrice { get; set; }
        public string BookName { get; set; }
        public string BookDescription { get; set; }
        public string BookImagePath { get; set; }
        public double BookRank { get; set; }
        public string BookAuthorName { get; set; }
    }


    public class BookCreateViewModel
    {
        public int Isbn { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int PublishId { get; set; }

        public List<int> CategoriesIdList { get; set; }
        public List<int> TagsIdList { get; set; }
        public List<int> AuthorsIdList { get; set; }
        public string PicturePath { get; set; }
    }
}
