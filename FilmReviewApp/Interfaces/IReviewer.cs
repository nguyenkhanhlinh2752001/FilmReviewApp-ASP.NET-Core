using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmReviewApp.Models;

namespace FilmReviewApp.Interfaces
{
    public interface IReviewer
    {
        ICollection<Reviewer> GetReviewers();
        Reviewer GetReviewer(int id);
        ICollection<Review> GetReviewsByReviewer(int id);
        bool ReviewerExists(int id);
    }
}
