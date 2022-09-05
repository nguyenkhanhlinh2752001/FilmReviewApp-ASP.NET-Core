using FilmReviewApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController: Controller
    {
        private readonly ICategory _icategory;
        public CategoryController(ICategory icategory)
        {
            _icategory=icategory;
        }

        [HttpGet]
        public IActionResult GetCategories(){
            var categories = _icategory.GetCategories();
            if(!ModelState.IsValid)
                return BadRequest();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id){
           if(!_icategory.CategoryExists(id))
                return NotFound();
            var category=_icategory.GetCategory(id);
            if(!ModelState.IsValid)
                return BadRequest();
            return Ok(category);
        }

        [HttpGet("{id}/films")]
        public IActionResult GetFilmsByCategory(int id){
            if(!_icategory.CategoryExists(id))
                return NotFound();
            var films=_icategory.GetFilmsByCategory(id);
            if(!ModelState.IsValid)
                return BadRequest();
            return Ok(films);
        }
    }
}
