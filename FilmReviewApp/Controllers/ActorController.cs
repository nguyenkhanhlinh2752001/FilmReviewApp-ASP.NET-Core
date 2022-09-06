using AutoMapper;
using FilmReviewApp.DTO;
using FilmReviewApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmReviewApp.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ActorController: Controller
    {
        private readonly IMapper _mapper;
        private readonly IActor _iactor;
        public ActorController(IActor iactor, IMapper mapper)
        {
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
    }
}
