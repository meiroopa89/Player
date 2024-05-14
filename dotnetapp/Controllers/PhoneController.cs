using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;
using dotnetapp.Data;

namespace dotnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CarController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Car
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            return await _context.Cars.ToListAsync();
        }

        // GET: api/Car/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            var Car = await _context.Cars.FindAsync(id);

            if (Car == null)
            {
                return NotFound();
            }

            return Car;
        }

        // POST: api/Car
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(Car Car)
        {
            _context.Cars.Add(Car);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCar", new { id = Car.id }, Car);
        }

        // DELETE: api/Car/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> DeleteCar(int id)
        {
            var Car = await _context.Cars.FindAsync(id);
            if (Car == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(Car);
            await _context.SaveChangesAsync();

            return Car;
        }

    }
}
