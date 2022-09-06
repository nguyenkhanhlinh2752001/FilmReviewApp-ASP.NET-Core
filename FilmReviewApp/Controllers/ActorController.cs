using AutoMapper;
using FilmReviewApp.DTO;
using FilmReviewApp.Interfaces;
using FilmReviewApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController: Controller
    {
        private readonly IMapper _mapper;
        private readonly IActor _iactor;
        private readonly ICountry _icountry;
        public ActorController(IMapper mapper, IActor iactor, ICountry icountry)
        {
            _icountry = icountry;
            _iactor = iactor;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetActors(){
            var actors = _mapper.Map<List<ActorDTO>>(_iactor.GetActors());
            if(!ModelState.IsValid)
                return BadRequest();
            return Ok(actors);
        }

        [HttpGet("{id}")]
        public IActionResult GetActor(int id){
            if(!_iactor.ActorExists(id))
                return NotFound();
            var category = _mapper.Map<ActorDTO>(_iactor.GetActor(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(category);
        }

        [HttpGet("film/{id}")]
        public IActionResult GetActorsByFilm(int id){
            if(!_iactor.ActorExists(id))
                return NotFound();
            var actors=_mapper.Map<List<ActorDTO>>(_iactor.GetActorsByFilm(id));
            if(!ModelState.IsValid)
                return BadRequest();
            return Ok(actors);
        }

        [HttpGet("{id}/films")]
        public IActionResult GetFilmsByActor(int id){
            if(!_iactor.ActorExists(id))
                return NotFound();
            var films=_mapper.Map<List<FilmDTO>>(_iactor.GetFilmsByActor(id));
            if(!ModelState.IsValid)
                return BadRequest();
            return Ok(films);
        }

        [HttpPost]
        public IActionResult CreateActor( [FromQuery] int countryId, [FromBody] ActorDTO actorDto){
            if(!ModelState.IsValid) return BadRequest();

            var actor = _mapper.Map<Actor>(actorDto);
            actor.Country=_icountry.GetCountry(countryId);

            if(!_iactor.CreateActor(actor)){
                ModelState.AddModelError("", "Error");
                return StatusCode(500, ModelState);
            }
            return Ok("Actor created successfully");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateActor( int id, [FromBody] ActorDTO actorDto){
            if(!_iactor.ActorExists(id)) return NotFound();
            if(!ModelState.IsValid) return BadRequest();
            actorDto.Id=id;
            var actor = _mapper.Map<Actor>(actorDto);
            if(!_iactor.UpdateActor(actor)) return StatusCode(500, ModelState);
            return Ok(actor);
        }
    }
}
