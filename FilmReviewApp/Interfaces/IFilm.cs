using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmReviewApp.Models;

namespace FilmReviewApp.Interfaces
{
    public interface IFilm
    {
        ICollection<Film> GetFilms();
    }
}
