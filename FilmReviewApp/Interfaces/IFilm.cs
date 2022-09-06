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
        bool CreateFilm(int actorId, int categoryId, Film film);
        bool UpdateFilm(int actorId, int categoryId, Film film);
        bool DeleteFilm(Film film);
        bool Save();
    }
}
