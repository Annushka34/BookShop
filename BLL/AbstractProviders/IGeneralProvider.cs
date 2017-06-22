using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using BLL.ViewModels;

namespace BLL.AbstractProviders
{
    public interface IGeneralProvider
    {
        CategoryUIModel CreateNewCategory(CategoryViewModel categoryModel);
        List<CategoryUIModel> GetAllCategoriesNames();
        AuthorUIModel CreateNewAuthor(AuthorViewModel authorModel);
        List<AuthorUIModel> GetAllAuthorsNames();
        TagUIModel CreateNewTag(TagViewModel tagModel);
        List<TagUIModel> GetAllTagsNames();
        ReviewUIModel CreateNewReview(ReviewViewModel reviewModel);
        List<ReviewUIModel> GetAllReviewsByCustomer(int customerID);
        List<ReviewUIModel> GetAllReviewsByBook(int bookId);
        PublishUIModel CreateNewPublish(PublishViewModel publishModel);
        List<PublishUIModel> GetAllPublishNames();
    }
}
