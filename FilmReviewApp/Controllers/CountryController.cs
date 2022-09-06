using AutoMapper;
using FilmReviewApp.DTO;
using FilmReviewApp.Interfaces;
using FilmReviewApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController: Controller
    {
        private readonly ICountry _icountry;
        private readonly IMapper _mapper;
        
        public CountryController(ICountry icountry, IMapper mapper)
        {
            _mapper = mapper;
            _icountry = icountry;  
        }

        [HttpGet]
        public IActionResult GetCountries(){
            var countries = _mapper.Map<List<CountryDTO>>(_icountry.GetCountries());
            if(!ModelState.IsValid)
                return BadRequest();
            return Ok(countries);
        }

        [HttpGet("{id}")]
        public IActionResult GetCountry(int id){
           if(!_icountry.CountryExists(id))
                return NotFound();
            var country=_mapper.Map<CountryDTO>(_icountry.GetCountry(id));
            if(!ModelState.IsValid)
                return BadRequest();
            return Ok(country);
        }

        [HttpGet("{id}/actors")]
        public IActionResult GetActorsByCountry(int id){
            if(!_icountry.CountryExists(id))
                return NotFound();
            var actors=_mapper.Map<List<ActorDTO>>(_icountry.GetActorsByCountry(id));
            if(!ModelState.IsValid)
                return BadRequest();
            return Ok(actors);
        }

        [HttpGet("actor/{id}")]
        public IActionResult GetCountryByActor(int id){
            if(!_icountry.CountryExists(id))
                return NotFound();
            var country=_mapper.Map<CountryDTO>(_icountry.GetCountryByActor(id));
            if(!ModelState.IsValid)
                return BadRequest();
            return Ok(country);
        }

        [HttpPost]
        public IActionResult CreateCountry( [FromBody] CountryDTO countryDto){
            if(!ModelState.IsValid) return BadRequest();

            var country = _mapper.Map<Country>(countryDto);
            
            if(!_icountry.CreateCountry(country)){
                return StatusCode(500, ModelState);
            }
            return Ok("Country created successfully");
        }
        
    }
}
