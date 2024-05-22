using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Data;

namespace dotnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FitnessController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FitnessController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FitnessClass
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fitness>>> GetFitnessClasses()
        {
            return await _context.FitnessClass.ToListAsync();
        }

        // GET: api/FitnessClass/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fitness>> GetFitnessClass(int id)
        {
            var fitnessClass = await _context.FitnessClass.FindAsync(id);

            if (fitnessClass == null)
            {
                return NotFound();
            }

            return fitnessClass;
        }

        // POST: api/FitnessClass
        [HttpPost]
        public async Task<ActionResult<Fitness>> PostFitnessClass(Fitness fitnessClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.FitnessClass.Add(fitnessClass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFitnessClass", new { id = fitnessClass.classId }, fitnessClass);
        }

        // DELETE: api/FitnessClass/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFitnessClass(int id)
        {
            var fitnessClass = await _context.FitnessClass.FindAsync(id);
            if (fitnessClass == null)
            {
                return NotFound();
            }

            _context.FitnessClass.Remove(fitnessClass);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
