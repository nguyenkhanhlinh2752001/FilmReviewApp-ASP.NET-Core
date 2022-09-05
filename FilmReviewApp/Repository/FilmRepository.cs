using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public ICollection<Film> GetFilms(){
            return _context.Films.OrderBy(f => f.Id).ToList();
        }

    }
}
