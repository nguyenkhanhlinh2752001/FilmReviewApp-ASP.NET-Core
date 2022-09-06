using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmReviewApp.DTO;
using FilmReviewApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmReviewApp.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ReviewController: Controller
    {
        private readonly IMapper _mapper;
        private readonly IReview _ireview;

        public ReviewController(IReview ireview, IMapper mapper)
        {
            _ireview = ireview;
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
    }
}
