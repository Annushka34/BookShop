using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.AbstractRepository;
using DAL.Entity;

namespace DAL.ConcreteRepositories
{
    class ReviewRepository:IReviewRepository
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
            try
            {
                Review review = _db.Reviews.SingleOrDefault(x => x.Id == reviewId);
                _db.Reviews.Remove(review);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Get
        public List<Review> GetAllReviewsByBook(Book book)
        {
            List<Review> reviews = _db.Reviews.Where(x => x.Book == book).ToList();
            return reviews;
        }

        public List<Review> GetAllReviewsByCustomer(Customer customer)
        {
            List<Review> reviews = _db.Reviews.Where(x => x.Customer == customer).ToList();
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
