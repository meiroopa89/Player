using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using dotnetapp.Models;

namespace dotnetapp.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewController: ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ReviewController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Review>> AddReview(Review review, int movieId)
        {
            review.MovieID = movieId;
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{movieId}")]
        public async Task<ActionResult<Review>> GetReview (int movieId)
        {
            var Review = _context.Reviews.FindAsync();

            if()
        }

    }
}