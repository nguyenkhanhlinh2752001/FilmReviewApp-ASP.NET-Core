using AutoMapper;
using FilmReviewApp.DTO;
using FilmReviewApp.Interfaces;
using FilmReviewApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewerController: Controller
    {
         private readonly IMapper _mapper;
        private readonly IReviewer _ireviewer;

        public ReviewerController(IReviewer ireviewer, IMapper mapper)
        {
            _ireviewer = ireviewer;
            _mapper = mapper;         
        }

        [HttpGet]
        public IActionResult GetReviewers(){
            var reviewers = _mapper.Map<List<ReviewerDTO>>(_ireviewer.GetReviewers());
            if(!ModelState.IsValid)
                return BadRequest();
            return Ok(reviewers);
        }

        [HttpGet("{id}")]
        public IActionResult GetReviewer(int id){
           if(!_ireviewer.ReviewerExists(id))
                return NotFound();
            var reviewer=_mapper.Map<ReviewerDTO>(_ireviewer.GetReviewer(id));
            if(!ModelState.IsValid)
                return BadRequest();
            return Ok(reviewer);
        }

        [HttpGet("{id}/reviews")]
        public IActionResult GetReviewsByReviewer(int id){
            if(!_ireviewer.ReviewerExists(id))
                return NotFound();
            var reviews=_mapper.Map<List<ReviewDTO>>(_ireviewer.GetReviewsByReviewer(id));
            if(!ModelState.IsValid)
                return BadRequest();
            return Ok(reviews);
        }

        [HttpPost]
        public IActionResult CreateReviewer( [FromBody] ReviewerDTO reviewerDto){
            if(!ModelState.IsValid) return BadRequest();

            var reviewer = _mapper.Map<Reviewer>(reviewerDto);

            if(!_ireviewer.CreateReviewer(reviewer)){
                ModelState.AddModelError("", "Error");
                return StatusCode(500, ModelState);
            }
            return Ok(reviewer);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateReviewer( int id, [FromBody] ReviewerDTO reviewerDto ){
            if(!_ireviewer.ReviewerExists(id)) return NotFound();
            if(!ModelState.IsValid) return BadRequest();
            reviewerDto.Id=id;
            var reviewer = _mapper.Map<Reviewer>(reviewerDto);
            if(!_ireviewer.UpdateReviewer(reviewer)) return StatusCode(500, ModelState);
            return Ok(reviewer);
        }
    }
}
