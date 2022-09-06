using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmReviewApp.DTO;
using FilmReviewApp.Interfaces;
using FilmReviewApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController: Controller
    {
        private readonly IReview _ireview;
        public readonly IReviewer _ireviewer;
        private readonly IFilm _ifilm;
        private readonly IMapper _mapper;

        public ReviewController(IReview ireview, IFilm ifilm, IReviewer ireviewer, IMapper mapper)
        {
            _ireview = ireview;
            _ireviewer = ireviewer;
            _ifilm = ifilm;
            _mapper = mapper;         
        }

        [HttpGet]
        public IActionResult GetReviews(){
            var reviews = _mapper.Map<List<ReviewDTO>>(_ireview.GetReviews());
            if(!ModelState.IsValid)
                return BadRequest();
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public IActionResult GetReview(int id){
           if(!_ireview.ReviewExists(id))
                return NotFound();
            var review=_mapper.Map<ReviewDTO>(_ireview.GetReview(id));
            if(!ModelState.IsValid)
                return BadRequest();
            return Ok(review);
        }

        [HttpGet("film/{id}")]
        public IActionResult GetReviewsByFilm(int id){
            if(!_ireview.ReviewExists(id))
                return NotFound();
            var reviews=_mapper.Map<List<ReviewDTO>>(_ireview.GetReviewsByFilm(id));
            if(!ModelState.IsValid)
                return BadRequest();
            return Ok(reviews);
        }

        [HttpPost]
        public IActionResult CreateReview( [FromQuery] int reviewerId, [FromQuery] int filmId, [FromBody] ReviewDTO reviewDto){
            if(!ModelState.IsValid) return BadRequest();

            var review = _mapper.Map<Review>(reviewDto);
            review.Reviewer = _ireviewer.GetReviewer(reviewerId);
            review.Film=_ifilm.GetFilm(filmId);

            if(!_ireview.CreateReview(review)){
                ModelState.AddModelError("", "Error");
                return StatusCode(500, ModelState);
            }
            return Ok("Review created successfully");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateReview( int id, [FromBody] ReviewDTO reviewDto ){
            if(!_ireview.ReviewExists(id)) return NotFound();
            if(!ModelState.IsValid) return BadRequest();
            reviewDto.Id=id;
            var review = _mapper.Map<Review>(reviewDto);
            if(!_ireview.UpdateReview(review)) return StatusCode(500, ModelState);
            return Ok(review);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReview(int id){
            if(!_ireview.ReviewExists(id)) return NotFound();
            var review = _ireview.GetReview(id);
            if(!ModelState.IsValid) return BadRequest();
            if(!_ireview.DeleteReview(review)) return StatusCode(500, ModelState);
            return NoContent();
        }
        
    }
}
