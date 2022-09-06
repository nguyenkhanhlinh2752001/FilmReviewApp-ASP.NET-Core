using FilmReviewApp.Models;

namespace FilmReviewApp.Interfaces
{
    public interface IReview
    {
        ICollection<Review> GetReviews();
        Review GetReview(int id);
        ICollection<Review> GetReviewsByFilm(int id);
        bool ReviewExists(int id);
        bool CreateReview(Review review);
        bool UpdateReview(Review review);
        bool DeleteReview(Review review);
        bool Save();
    }
}
