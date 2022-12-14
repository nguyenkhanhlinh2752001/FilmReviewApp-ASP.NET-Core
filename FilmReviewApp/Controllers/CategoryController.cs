using AutoMapper;
using FilmReviewApp.DTO;
using FilmReviewApp.Interfaces;
using FilmReviewApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController: Controller
    {
        private readonly ICategory _icategory;
        private readonly IMapper _mapper;
        public CategoryController(ICategory icategory, IMapper mapper)
        {
            _mapper = mapper;
            _icategory=icategory;
        }

        [HttpGet]
        public IActionResult GetCategories(){
            var categories = _mapper.Map<List<CategoryDTO>>(_icategory.GetCategories());
            if(!ModelState.IsValid)
                return BadRequest();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id){
            if(!_icategory.CategoryExists(id))
                return NotFound();
            var category = _mapper.Map<CategoryDTO>(_icategory.GetCategory(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(category);
        }

        [HttpGet("{id}/films")]
        public IActionResult GetFilmsByCategory(int id){
            if(!_icategory.CategoryExists(id))
                return NotFound();
            var films=_mapper.Map<List<FilmDTO>>(_icategory.GetFilmsByCategory(id));
            if(!ModelState.IsValid)
                return BadRequest();
            return Ok(films);
        }

        [HttpPost]
        public IActionResult CreateCategory( [FromBody] CategoryDTO categoryDto){
            if(!ModelState.IsValid) return BadRequest();
            var category = _mapper.Map<Category>(categoryDto);         
            if(!_icategory.CreateCategory(category)){
                return StatusCode(500, ModelState);
            }
            return Ok("Category created successfully");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory( int id, [FromBody] CategoryDTO categoryDto){
            if(!_icategory.CategoryExists(id)) return NotFound();
            if(!ModelState.IsValid) return BadRequest();
            categoryDto.Id=id;
            var category = _mapper.Map<Category>(categoryDto);
            if(!_icategory.UpdateCategory(category)) return StatusCode(500, ModelState);
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id){
            if(!_icategory.CategoryExists(id)) return NotFound();
            var category = _icategory.GetCategory(id);
            if(!ModelState.IsValid) return BadRequest();
            if(!_icategory.DeleteCategory(category)) return StatusCode(500, ModelState);
            return NoContent();
        }
        
    }
}
