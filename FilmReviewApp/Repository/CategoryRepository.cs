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
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(c=>c.Id == id).FirstOrDefault();
        }

        public ICollection<Film> GetFilmsByCategory(int id)
        {
            return _context.FilmCategories.Where(c=>c.CategoryId == id).Select(c=>c.Film).ToList();
        }
    }
}
