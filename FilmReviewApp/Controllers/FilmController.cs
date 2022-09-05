using FilmActorApp.Database;
using FilmReviewApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : Controller
    {
        private readonly IFilm _ifilm;
        private readonly DataContext _context;
        public FilmController(IFilm ifilm, DataContext context){
            _ifilm = ifilm;       
            _context = context;
        }

        [HttpGet]
        public IActionResult GetFilms(){
            var films=_ifilm.GetFilms();
            if(!ModelState.IsValid)
                return BadRequest();
            return Ok(films);
        }
    }
}
