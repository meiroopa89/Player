using System;
using dotnetapp.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections;

namespace dotnetapp.Models
{
    public class MovieController: ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MovieController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<Movie>> AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetMovies", new {movieId = movie.MovieID}, movie);
        }

        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            var movies = await _context.Movies.ToListAsync();

            foreach(var movie in movies)
            {
                var reviews = await _context.Reviews.Where(m => m.MovieID == movie.MovieID).ToListAsync();

                movies.Reviews = reviews;
            }

            return Ok(movies);
        
        }

        public async Task<ActionResult<Movie>> GetMovie (int movieId)
        {
            var Movie = _context.Movies.FindAsync(movieId);
            var reviews = await _context.Reviews.Where(r => r.MovieID == movieId).ToListAsync();

            Movie.Reviews = reviews;

            if(Movie==null)
            {
                return NotFound();
            }

            return Ok(Movie);
        }
    }
}