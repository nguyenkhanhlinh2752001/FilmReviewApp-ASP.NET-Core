using FilmReviewApp.Models;

namespace FilmReviewApp.Interfaces
{
    public interface ICategory
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Film> GetFilmsByCategory(int id);
        bool CategoryExists(int id);

        bool CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool Save();
        
    }
}
