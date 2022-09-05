using FilmReviewApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : Controller
    {
        private readonly IFilm _ifilm;
        public FilmController(IFilm ifilm){
            _ifilm = ifilm;      
        }

        [HttpGet]
        public IActionResult GetFilms(){
            var films=_ifilm.GetFilms();
            if(!ModelState.IsValid)
                return BadRequest();
            return Ok(films);
        }

        [HttpGet("{id}")]
        public IActionResult GetFilm(int id){
            if(!_ifilm.FilmExists(id))
                return NotFound();
            var film=_ifilm.GetFilm(id);
            if(!ModelState.IsValid)
                return BadRequest();
            return Ok(film);
        }

        [HttpGet("{id}/rating")]
        public IActionResult GetFilmRating(int id){
            if(!_ifilm.FilmExists(id))
                return NotFound();
            var rating=_ifilm.GetFilmRating(id);
            if(!ModelState.IsValid)
                return BadRequest();
            return Ok(rating);
        }
    }
}
