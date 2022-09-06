using FilmReviewApp.Models;

namespace FilmReviewApp.Interfaces
{
    public interface IReviewer
    {
        ICollection<Reviewer> GetReviewers();
        Reviewer GetReviewer(int id);
        ICollection<Review> GetReviewsByReviewer(int id);
        bool ReviewerExists(int id);
        bool CreateReviewer(Reviewer reviewer);
        bool UpdateReviewer(Reviewer reviewer);
        bool Save();

    }
}
