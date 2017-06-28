
using System.Collections.Generic;
using DAL.Entity;
using System;

namespace BLL.ViewModels
{
    public class CategoryUIModel//список категорій на юай
    {
        public CategoryUIModel(Category category)
        {
            Id = category.Id;
            CategoryName = category.Name;
        }
     
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
    public class CategoryViewModel//приходить з юай при створенні нової категорї
    {
        public CategoryViewModel()
        {
            BooksId = new List<int>();
        }
        public string CategoryName { get; set; }
        public List<int> BooksId { get; set; }
    }
    public class ReviewUIModel//іде на юай коментар до книжки від конкретного кастомера
    {
        public ReviewUIModel(Review review)
        {
            Id = review.Id;
            ReviewDate = review.ReviewDate;
            BookQuality = review.BookQuality;
            ReviewDescription = review.ReviewDescription;
            BookId = review.BookId;
            CustomerId = review.CustomerId;
        }
        public int Id { get; set; }
        public DateTime ReviewDate { get; set; }
        public int BookQuality { get; set; }
        public string ReviewDescription { get; set; }
        public int BookId { get; set; }
        public int CustomerId { get; set; }
    }
    public class ReviewViewModel//приходить з юай при створенні нового коментаря
    {
        public string ReviewDescription { get; set; }
        public int BookId { get; set; }
        public int CustomerId { get; set; }
        public DateTime ReviewDate { get; set; }
        public int BookQuality { get; set; }
    }
    public class TagUIModel//іде на юай список книжок до конкретного тега
    {
        public TagUIModel(Tag tag)
        {
            Id = tag.Id;
            TagName = tag.Name;
        }
        public int Id { get; set; }
        public string TagName { get; set; }
    }
    public class TagViewModel//приходить з юай при створенні нового тега
    {
        public TagViewModel()
        {
            BooksId = new List<int>();
        }
        public int Id { get; set; }
        public string TagName { get; set; }
        public List<int> BooksId { get; set; }
    }
    public class PublishUIModel//іде на юай список Паблішів без книжок
    {
        public PublishUIModel(Publish publish)
        {
            Id = publish.Id;
            PublishName = publish.Name;
        }
        public int Id { get; set; }
        public string PublishName { get; set; }
    }
    public class PublishViewModel//приходить з юай при створенні нового пабліша
    {
        public int Id { get; set; }
        public string PublishName { get; set; }
        public List<int> BooksId { get; set; }
    }

    public class SearchViewModel
    {
        public SearchViewModel()
        {
            CategoryId = -1;
            AuthorId = -1;
            PublishId = -1;
            TagId = -1;
            BookName = "";
        }
        public SearchViewModel(int catId,int autId, int pubId,int tagId,string name)
        {
            CategoryId = catId;
            AuthorId = autId;
            PublishId = pubId;
            TagId = tagId;
            BookName = name;
        }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public int PublishId { get; set; }
        public int TagId { get; set; }
        public string BookName { get; set; }

    }
}
