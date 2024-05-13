using System;
using dotnetapp.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections;

namespace dotnetapp.Models
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController: ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MovieController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetMovies", new {movieId = movie.MovieID}, movie);
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            var movies = await _context.Movies.ToListAsync();

            foreach(var movie in movies)
            {
                var reviews = await _context.Reviews.Where(m => m.MovieID = movie.MovieID).ToListAsync();
                movie.Reviews = reviews;
            }

            return Ok(movies);
        
        }

        [HttpGet("{movieId}")]
        public async Task<ActionResult<Movie>> GetMovie (int movieId)
        {
            var Movie = await _context.Movies.FindAsync(movieId);
            

            if(Movie==null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews.Where(r => r.MovieID == movieId).ToListAsync();

            Movie.Reviews = reviews;

            return Ok(Movie);
        }
    }
}