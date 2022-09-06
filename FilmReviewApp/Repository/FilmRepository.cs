using FilmActorApp.Database;
using FilmReviewApp.Interfaces;
using FilmReviewApp.Models;

namespace FilmReviewApp.Repository
{
    public class FilmRepository : IFilm
    {
        private readonly DataContext _context;
        public FilmRepository(DataContext context){
            _context = context;
        }

        public bool CreateFilm(int actorId, int categoryId, Film film)
        {
            var actor = _context.Actors.Where(a => a.Id == actorId).FirstOrDefault();
            var category = _context.Categories.Where(c => c.Id == categoryId).FirstOrDefault();
            var filmActor = new FilmActor()
            {
                Film = film,
                Actor = actor,
            };

            var filmCategory = new FilmCategory()
            {
                Film = film,
                Category = category
            };
            _context.Add(filmActor);
            _context.Add(filmCategory);
            _context.Add(film);

            return Save();

        }

        public bool FilmExists(int id)
        {
            return _context.Films.Any(f=>f.Id == id);
        }

        public Film GetFilm(int id)
        {
            return _context.Films.Where(f=>f.Id == id).FirstOrDefault();
        }

        public Film GetFilm(string name)
        {
            return _context.Films.Where(f=>f.Name == name).FirstOrDefault();
        }

        public decimal GetFilmRating(int id)
        {
           var review = _context.Reviews.Where(r => r.Film.Id == id);
            if (review.Count() <= 0)
                return 0;
            return ((decimal)review.Sum(r => r.Rating) / review.Count());
        }

        public ICollection<Film> GetFilms(){
            return _context.Films.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
