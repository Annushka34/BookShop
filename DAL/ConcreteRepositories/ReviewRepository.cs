using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.AbstractRepository;
using DAL.Entity;

namespace DAL.ConcreteRepositories
{
    class ReviewRepository : IReviewRepository
    {
        MyContext _db;
        public ReviewRepository(MyContext db)
        {
            _db = db;
        }
        #region CRUD
        public Review CreateReview(Review review)
        {
            _db.Reviews.Add(review);
            _db.SaveChanges();
            return review;
        }
        public bool DeleteReview(int reviewId)
        {
            Review review = GetReviewById(reviewId);
            if (review == null)
            {
                return false;
            }
            _db.Reviews.Remove(review);
            _db.SaveChanges();
            return true;
        }
        #endregion

        #region Get
        public List<Review> GetAllReviewsByBook(int bookId)
        {
            List<Review> reviews = _db.Reviews.Where(x => x.BookId == bookId).ToList();
            return reviews;
        }

        public List<Review> GetAllReviewsByCustomer(int customerId)
        {
            List<Review> reviews = _db.Reviews.Where(x => x.CustomerId == customerId).ToList();
            return reviews;
        }

        public List<Review> GetAllReviewsByDate(DateTime date)
        {
            List<Review> reviews = _db.Reviews.Where(x => x.ReviewDate == date).ToList();
            return reviews;
        }
        public Review GetReviewById(int reviewId)
        {
            Review review = _db.Reviews.SingleOrDefault(x => x.Id == reviewId);
            return review;
        }
        #endregion
    }
}
