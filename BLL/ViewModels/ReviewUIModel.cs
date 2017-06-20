using DAL.Entity;
using System;

namespace BLL.ViewModels
{
    public class ReviewUIModel
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
}