using AutoMapper;
using FilmReviewApp.DTO;
using FilmReviewApp.Interfaces;
using FilmReviewApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : Controller
    {
        private readonly IFilm _ifilm;
        private readonly IMapper _mapper;
        private readonly IActor _iactor;
        public FilmController( IMapper mapper,IFilm ifilm, IActor iactor){
            _mapper = mapper;
            _ifilm = ifilm;      
            _iactor = iactor;
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

        [HttpPost]
        public IActionResult CreateFilm([FromQuery] int actorId, [FromQuery] int categoryId, [FromBody] FilmDTO filmDto){

            if(!ModelState.IsValid) return BadRequest();

            var film = _mapper.Map<Film>(filmDto);
            
            if(!_ifilm.CreateFilm(actorId, categoryId, film)){
                ModelState.AddModelError("", "Error");
                return StatusCode(500, ModelState);
            }
            return Ok("Film created successfully");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFilm( int id, [FromQuery] int actorId, [FromQuery] int categoryId, [FromBody] FilmDTO filmDto ){
            if(!_ifilm.FilmExists(id)) return NotFound();
            if(!ModelState.IsValid) return BadRequest();
            filmDto.Id=id;
            var film = _mapper.Map<Film>(filmDto);
            if(!_ifilm.UpdateFilm( actorId, categoryId, film)) return StatusCode(500, ModelState);
            return Ok(film);
        }
    }
}
