using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Exceptions; 
using dotnetapp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapp.Controllers
{

public class BatchController : Controller
{
    private readonly ApplicationDbContext _context;

    public BatchController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult AvailableBatches()
    {
        var availableBatches = _context.Batches.ToList();
        return View(availableBatches);
    }

    public IActionResult BookedBatches()
    {
        var bookedBatches = _context.Batches
            .Where(b => b.Students.Count > 0)
            .ToList();
        return View(bookedBatches);
    }

    [HttpPost]
    public IActionResult DeleteBatch(int id)
    {
        var batch = _context.Batches.Find(id);
        if (batch == null)
        {
            return NotFound();
        }

        _context.Batches.Remove(batch);
        _context.SaveChanges();

        return RedirectToAction("AvailableBatches"); // Redirect to the appropriate action after deletion
    }

}
}