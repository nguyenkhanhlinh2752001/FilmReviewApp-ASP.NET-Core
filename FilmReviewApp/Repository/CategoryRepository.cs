using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmActorApp.Database;
using FilmReviewApp.Interfaces;
using FilmReviewApp.Models;

namespace FilmReviewApp.Repository
{
    public class CategoryRepository : ICategory
    {
        private readonly DataContext _context; 
        
        public CategoryRepository(DataContext context){
            _context = context;
        }
        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c=>c.Id == id);
        }

        public ICollection<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Category GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Film> GetFilmsByCategory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
