using DAL.Entity;
using System.Collections.Generic;

namespace BLL.ViewModels
{
   
        public class BookUIModel//список книжок на юай
        {
            public BookUIModel(Book book)
            {
                Id = book.Id;
                BookName = book.Name;    
            }
            public int Id { get; set; }
            public string BookName { get; set; }
        }
    public class BookUIModelWithCollections//список книжок на юай зі всіма коллекціями
    {
        public BookUIModelWithCollections(Book book)
        {
            Isbn = book.Isbn;
            Price = book.Price;
            Name = book.Name;
            Description = book.Description;
            PicturePath = book.Picture.PicturePath;
            PublishId = book.PublishId;

            Authors = new List<AuthorUIModelWithBooks>();
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

        public List<AuthorUIModelWithBooks> Authors { get; set; }
        public List<TagUIModel> Tags { get; set; }
        public List<CategoryUIModel> Categories { get; set; }
        public List<ReviewUIModel> Reviews { get; set; }
        
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
