using AutoMapper;
using FilmReviewApp.DTO;
using FilmReviewApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmReviewApp.Controllers
{
    [Route("api/[controller]s")]
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
    }
}
