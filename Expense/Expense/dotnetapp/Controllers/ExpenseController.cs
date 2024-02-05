using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using dotnetapp.Data;
using dotnetapp.Model;

namespace dotnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExpenseController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody] ExpenseModel expense)
        {
            if (ModelState.IsValid)
            {
                // Assuming you have a database to store expenses
                _context.Expenses.Add(expense);
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetAll), new { id = expense.ExpenseID }, expense);
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ExpenseModel>> GetAll()
        {
            var expenses = _context.Expenses.ToList();
            return Ok(expenses);
        }
    }
}
