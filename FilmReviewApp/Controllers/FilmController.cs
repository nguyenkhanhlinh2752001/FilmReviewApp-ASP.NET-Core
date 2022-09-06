using AutoMapper;
using FilmReviewApp.DTO;
using FilmReviewApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmReviewApp.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class FilmController : Controller
    {
        private readonly IFilm _ifilm;
        private readonly IMapper _mapper;
        public FilmController(IFilm ifilm, IMapper mapper){
            _mapper = mapper;
            _ifilm = ifilm;      
        }

        [HttpGet]
        public IActionResult GetFilms(){
            var films=_mapper.Map<List<FilmDTO>>(_ifilm.GetFilms());
            if(!ModelState.IsValid)
                return BadRequest();
            return Ok(films);
        }

        [HttpGet("{id}")]
        public IActionResult GetFilm(int id){
            if(!_ifilm.FilmExists(id))
                return NotFound();
            var film=_mapper.Map<List<FilmDTO>>(_ifilm.GetFilm(id));
            if(!ModelState.IsValid)
                return BadRequest();
            return Ok(film);
        }

        [HttpGet("{id}/rating")]
        public IActionResult GetFilmRating(int id){
            if(!_ifilm.FilmExists(id))
                return NotFound();
            var rating=_mapper.Map<List<FilmDTO>>(_ifilm.GetFilmRating(id));
            if(!ModelState.IsValid)
                return BadRequest();
            return Ok(rating);
        }
    }
}
