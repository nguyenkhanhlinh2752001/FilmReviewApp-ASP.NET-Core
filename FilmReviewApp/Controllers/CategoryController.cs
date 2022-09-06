using AutoMapper;
using FilmReviewApp.DTO;
using FilmReviewApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmReviewApp.Controllers
{
    [Route("api/[controller]s")]
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
    }
}
