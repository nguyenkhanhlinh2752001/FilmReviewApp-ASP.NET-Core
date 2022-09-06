using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmActorApp.Database;
using FilmReviewApp.Interfaces;
using FilmReviewApp.Models;

namespace FilmReviewApp.Repository
{
    public class ReviewerRepository : IReviewer
    {
        private readonly DataContext _context;
        public ReviewerRepository(DataContext context)
        {
            _context = context;
            
        }
        public Reviewer GetReviewer(int id)
        {
            return _context.Reviewers.Where(r => r.Id == id).FirstOrDefault();
        }

        public ICollection<Reviewer> GetReviewers()
        {
            return _context.Reviewers.ToList();
        }

        public ICollection<Review> GetReviewsByReviewer(int id)
        {
            return _context.Reviews.Where(r => r.Reviewer.Id==id).ToList();
        }

        public bool ReviewerExists(int id)
        {
            return _context.Reviewers.Any(r =>r.Id==id);
        }
    }
}
