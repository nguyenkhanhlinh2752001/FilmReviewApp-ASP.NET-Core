using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmActorApp.Database;
using FilmReviewApp.Interfaces;
using FilmReviewApp.Models;

namespace FilmReviewApp.Repository
{
    public class ReviewRepository : IReview
    {
        private readonly DataContext _context;
        public ReviewRepository(DataContext context)
        {
            _context = context;
            
        }

        public bool CreateReview(Review review)
        {
            _context.Reviews.Add(review);
            return Save();
        }

        public Review GetReview(int id)
        {
            return _context.Reviews.Where(r => r.Id == id).FirstOrDefault();
        }

        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.ToList();
        }

        public ICollection<Review> GetReviewsByFilm(int id)
        {
            return _context.Reviews.Where(r=>r.Film.Id==id).ToList();
        }

        public bool ReviewExists(int id)
        {
            return _context.Reviews.Any(r => r.Id==id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateReview(Review review)
        {
            _context.Reviews.Update(review);
            return Save();
        }
    }
}
