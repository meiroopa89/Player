using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.Versioning;
using System;

namespace dotnetapp.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController : ControllerBase
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
            return await _context.Movies.ToListAsync();
        }

        [HttpGet("{movieId}")]
        public async Task<ActionResult<Movie>> GetMovie(int movieId)
        {
            var Movie = _context.Movies.FindAsync(movieId);
            if(Movie==null)
            {
                return NotFound();
            }
            return Ok(Movie);
        }
    }
}