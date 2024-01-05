using Microsoft.AspNetCore.Mvc;
using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Controllers{
public class CandidateController : Controller
{
    private readonly ApplicationDbContext _context;

    public CandidateController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        // Get the list of candidates from the database and pass it to the view
        var candidates = _context.Candidates.Include(c => c.VerificationTasks).ToList();
        return View(candidates);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Candidate candidate)
    {
        if (ModelState.IsValid)
        {
            // Save the new candidate to the database
            _context.Candidates.Add(candidate);
            _context.SaveChanges();

            // Redirect to the Index page
            return RedirectToAction("Index", "Verification");
        }

        return View(candidate);
    }
}
}