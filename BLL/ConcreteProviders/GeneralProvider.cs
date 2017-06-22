using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using BLL.AbstractProviders;
using BLL.ViewModels;
using DAL.AbstractRepository;
using DAL.ConcreteRepositories;
using DAL.Entity;

namespace BLL.ConcreteProviders
{
    public class GeneralProvider : IGeneralProvider
    {
        private MyContext _db;

        public GeneralProvider()
        {
                _db=new MyContext();
        }
        public CategoryUIModel CreateNewCategory(CategoryViewModel categoryModel)
        {
            ICategoryRepository categoryRepository = new CategoryRepository(_db);
            IBookRepository bookRepository = new BookRepository(_db);
            Category category = new Category();
            category.Name = categoryModel.CategoryName;
            categoryRepository.CreateCategory(category);

            if (categoryModel.BooksId.Count != 0)
            {
                foreach (var id in categoryModel.BooksId)
                {
                    Book book = bookRepository.GetBookById(id);
                    book.Categories.Add(category);
                }
                _db.SaveChanges();
            }
            return new CategoryUIModel(category);
        }
        public List<CategoryUIModel> GetAllCategoriesNames()
        {
            ICategoryRepository userRepository = new CategoryRepository(_db);

            List<CategoryUIModel> categories = new List<CategoryUIModel>();

            foreach (var category in _db.Categories)
            {
                CategoryUIModel newCategory = new CategoryUIModel(category);
                categories.Add(newCategory);
            }
            return categories;
        }

        public AuthorUIModel CreateNewAuthor(AuthorViewModel authorModel)
        {
            IAuthorRepository authorRepository = new AuthorRepository(_db);
            IBookRepository bookRepository = new BookRepository(_db);
            Author author = new Author();
            author.FirstName = authorModel.FirstName;
            author.LastName = authorModel.LastName;

            authorRepository.CreateAuthor(author);
            if (authorModel.BooksId.Count != 0)
            {
                foreach (var id in authorModel.BooksId)
                {
                    Book book = bookRepository.GetBookById(id);
                    book.Authors.Add(author);
                }
                _db.SaveChanges();
            }
            return new AuthorUIModel(author);
        }
        public List<AuthorUIModel> GetAllAuthorsNames()
        {
            IAuthorRepository authorRepository = new AuthorRepository(_db);
            List<AuthorUIModel> authors = new List<AuthorUIModel>();

            foreach (var author in _db.Authors)
            {
                AuthorUIModel newAuthor = new AuthorUIModel(author);
                authors.Add(newAuthor);
            }
            return authors;
        }

        public TagUIModel CreateNewTag(TagViewModel tagModel)
        {
            ITagRepository tagRepository = new TagRepository(_db);
            IBookRepository bookRepository = new BookRepository(_db);
            Tag tag = new Tag();
            tag.Name = tagModel.TagName;
            tagRepository.CreateTag(tag);
            if (tagModel.BooksId.Count != 0)
            {
                foreach (var id in tagModel.BooksId)
                {
                    Book book = bookRepository.GetBookById(id);
                    book.Tags.Add(tag);
                }
                _db.SaveChanges();
            }
            return new TagUIModel(tag);
        }
        public List<TagUIModel> GetAllTagsNames()
        {
            List<TagUIModel> tags = new List<TagUIModel>();

            foreach (var tag in _db.Tags)
            {
                TagUIModel newTag = new TagUIModel(tag);
                tags.Add(newTag);
            }
            return tags;
        }

        public ReviewUIModel CreateNewReview(ReviewViewModel reviewModel)
        {
          IReviewRepository reviewRepository = new ReviewRepository(_db);
            Review review = new Review();
            review.BookId = reviewModel.BookId;
            review.CustomerId = reviewModel.CustomerId;
            review.BookQuality = reviewModel.BookQuality;
            review.ReviewDate = reviewModel.ReviewDate;
            review.ReviewDescription = reviewModel.ReviewDescription;
            reviewRepository.CreateReview(review);

            return new ReviewUIModel(review);
        }

        public List<ReviewUIModel> GetAllReviewsByCustomer(int customerID)
        {
            List<ReviewUIModel> reviewsUiModels = new List<ReviewUIModel>();
            IReviewRepository reviewRepository=new ReviewRepository(_db);
            List<Review> reviews = reviewRepository.GetAllReviewsByCustomer(customerID);
            foreach (var review in reviews)
            {
                ReviewUIModel reviewUi=new ReviewUIModel(review);
                reviewsUiModels.Add(reviewUi);
            }
            return reviewsUiModels;
        }

        public List<ReviewUIModel> GetAllReviewsByBook(int bookId)
        {
            List<ReviewUIModel> reviewsUiModels = new List<ReviewUIModel>();
            IReviewRepository reviewRepository = new ReviewRepository(_db);
            List<Review> reviews = reviewRepository.GetAllReviewsByBook(bookId);
            foreach (var review in reviews)
            {
                ReviewUIModel reviewUi = new ReviewUIModel(review);
                reviewsUiModels.Add(reviewUi);
            }
            return reviewsUiModels;
        }
        public PublishUIModel CreateNewPublish(PublishViewModel publishModel)
        {
            IPublishRepository publishRepository = new PublishRepository(_db);
            IBookRepository bookRepository = new BookRepository(_db);
            Publish publish = new Publish();
            publish.Name = publishModel.PublishName;
            publishRepository.CreatePublish(publish);

            return new PublishUIModel(publish);
        }

        public List<PublishUIModel> GetAllPublishNames()
        {
            List<PublishUIModel> publishes = new List<PublishUIModel>();

            foreach (var publish in _db.Publishes)
            {
                PublishUIModel publishUi = new PublishUIModel(publish);
                publishes.Add(publishUi);
            }
            return publishes;
        }
    }
}
