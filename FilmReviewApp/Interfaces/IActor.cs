using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmReviewApp.Models;

namespace FilmReviewApp.Interfaces
{
    public interface IActor
    {
        ICollection<Actor> GetActors();
        Actor GetActor(int id);
        ICollection<Actor> GetActorsByFilm(int id);
        ICollection<Film> GetFilmsByActor(int id);
        bool ActorExists(int id);
        bool CreateActor(Actor actor);
        bool Save();
    }
}
