using FilmActorApp.Database;
using FilmReviewApp.Interfaces;
using FilmReviewApp.Models;

namespace FilmReviewApp.Repository
{
    public class ActorRepository : IActor
    {
        private readonly DataContext _context;
        public ActorRepository(DataContext context)
        {
            _context = context;
            
        }
        public bool ActorExists(int id)
        {
            return _context.Actors.Any(a => a.Id == id);
        }

        public bool CreateActor(Actor actor)
        {
            _context.Add(actor);
            return Save();
        }

        public Actor GetActor(int id)
        {
            return _context.Actors.Where(a=>a.Id == id).FirstOrDefault();
        }

        public ICollection<Actor> GetActors()
        {
            return _context.Actors.ToList();
        }

        public ICollection<Actor> GetActorsByFilm(int id)
        {
            return _context.FilmActors.Where(a=>a.Film.Id == id).Select(a=>a.Actor).ToList();
        }

        public ICollection<Film> GetFilmsByActor(int id)
        {
            return _context.FilmActors.Where(a=>a.Actor.Id==id).Select(a=>a.Film).ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }
    }
}
