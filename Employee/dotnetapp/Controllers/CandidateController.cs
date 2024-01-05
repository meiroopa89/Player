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

    // public IActionResult Index()
    // {
    //     // Get the list of candidates from the database and pass it to the view
    //     var candidates = _context.Candidates.Include(c => c.VerificationTasks).ToList();
    //     return View(candidates);
    // }

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

    
//     public IActionResult Index()
// {
//     var verificationTasks = _context.VerificationTasks.Include(vt => vt.Candidate).ToList();

//     var tasksByCandidate = verificationTasks
//         .GroupBy(vt => vt.Candidate.CandidateName)
//         .Select(g => new
//         {
//             CandidateName = g.Key,
//             PendingCount = g.Count(t => t.Status == "Pending"),
//             OngoingCount = g.Count(t => t.Status == "Ongoing"),
//             CompletedCount = g.Count(t => t.Status == "Completed")
//         }).ToList();

//     return View(tasksByCandidate);
// }

}
}