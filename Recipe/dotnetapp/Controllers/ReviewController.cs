using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections;
using System;

namespace dotnetapp.Models
{
    public class ReviewController: ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReviewController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<Review>> AddReview(int movieId, Review review)
        {
            review.MovieID = movieId;
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return Ok();
        }

        public async Task<ActionResult<Review>> GetReviews(int movieId)
        {
            var reviews = await _context.Reviews.Where(r => r.MovieID == movieId).ToListAsync();

            return Ok(reviews);
        }
    }
}