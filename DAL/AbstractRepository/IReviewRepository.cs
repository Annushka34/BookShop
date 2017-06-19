using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace DAL.AbstractRepository
{
    public interface IReviewRepository
    {
        #region CRUD
        Review CreateReview(Review review);
        bool DeleteReview(int reviewId);
        #endregion

        #region Get
        List<Review> GetAllReviewsByCustomer(Customer customer);
        List<Review> GetAllReviewsByDate(DateTime date);
        List<Review> GetAllReviewsByBook(Book book);
        Review GetReviewById(int reviewId);
        #endregion
    }
}
