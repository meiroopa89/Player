using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;

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

        // GET: api/Expense
        [HttpGet]
        public IActionResult GetExpenses()
        {
            var expenses = _context.Expenses.ToList();
            return Ok(expenses);
        }

        // GET: api/Expense/5
        [HttpGet("{id}")]
        public IActionResult GetExpense(int id)
        {
            var expense = _context.Expenses.Find(id);

            if (expense == null)
            {
                return NotFound();
            }

            return Ok(expense);
        }

        // POST: api/Expense
        [HttpPost]
        public IActionResult PostExpense([FromBody] Expense expense)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Expenses.Add(expense);
            _context.SaveChanges();

            return CreatedAtAction("GetExpense", new { id = expense.Id }, expense);
        }

        // PUT: api/Expense/5
        [HttpPut("{id}")]
        public IActionResult PutExpense(int id, [FromBody] Expense expense)
        {
            if (id != expense.Id)
            {
                return BadRequest();
            }

            _context.Entry(expense).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Expenses.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Expense/5
        [HttpDelete("{id}")]
        public IActionResult DeleteExpense(int id)
        {
            var expense = _context.Expenses.Find(id);

            if (expense == null)
            {
                return NotFound();
            }

            _context.Expenses.Remove(expense);
            _context.SaveChanges();

            return Ok(expense);
        }
    }
}
