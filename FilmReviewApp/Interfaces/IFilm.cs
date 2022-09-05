using FilmReviewApp.Models;

namespace FilmReviewApp.Interfaces
{
    public interface IFilm
    {
        ICollection<Film> GetFilms();
        Film GetFilm(int id);
        Film GetFilm(string name);
        decimal GetFilmRating(int id);
        bool FilmExists(int id);
    }
}
