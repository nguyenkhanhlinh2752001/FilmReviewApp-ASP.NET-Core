using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmReviewApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmReviewApp.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController: Controller
    {
        private readonly ICountry _icountry;
        public CountryController(ICountry icountry)
        {
            _icountry = icountry;  
        }

        [HttpGet]
        public IActionResult GetCountries(){
            var countries = _icountry.GetCountries();
            if(!ModelState.IsValid)
                return BadRequest();
            return Ok(countries);
        }

        [HttpGet("{id}")]
        public IActionResult GetCountry(int id){
           if(!_icountry.CountryExists(id))
                return NotFound();
            var country=_icountry.GetCountry(id);
            if(!ModelState.IsValid)
                return BadRequest();
            return Ok(country);
        }

        [HttpGet("{id}/actors")]
        public IActionResult GetActorsByCountry(int id){
            if(!_icountry.CountryExists(id))
                return NotFound();
            var actors=_icountry.GetActorsByCountry(id);
            if(!ModelState.IsValid)
                return BadRequest();
            return Ok(actors);
        }

        [HttpGet("actor/{id}")]
        public IActionResult GetCountryByActor(int id){
            if(!_icountry.CountryExists(id))
                return NotFound();
            var actor=_icountry.GetCountryByActor(id);
            if(!ModelState.IsValid)
                return BadRequest();
            return Ok(actor);
        }
        
    }
}
