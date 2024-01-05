using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;
using System.Linq;

namespace dotnetapp.Controllers
{
public class VerificationController : Controller
{
    private readonly ApplicationDbContext _context;

    public VerificationController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Task(int candidateId)
    {
        var candidate = _context.Candidates.Find(candidateId);
        if (candidate == null)
        {
            return NotFound("Candidate not found.");
        }

        ViewBag.CandidateName = candidate.CandidateName;

        var newTask = new VerificationTask
        {
            CandidateID = candidateId,
            Status = "Pending" 
        };

        return View(newTask);
    }

    public IActionResult Create(){
        return View();
    }

    // // POST: /Verification/Create
    // 
    
    [HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Create(VerificationTask verificationTask)
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


 
    // public IActionResult Index()
    // {
    //     var verificationTasks = _context.VerificationTasks.Include(vt => vt.Candidate).ToList();
    //     return View(verificationTasks); 
    // }
//     public IActionResult Index(int? candidateId)
// {
//     if (candidateId != null)
//     {
//         ViewBag.SelectedCandidateId = candidateId;
//         var verificationTasks = _context.VerificationTasks
//             .Include(vt => vt.Candidate)
//             .Where(vt => vt.CandidateID == candidateId)
//             .ToList();

//         return View(verificationTasks);
//     }
//     else
//     {
//         ViewBag.SelectedCandidateId = "All";
//         var verificationTasks = _context.VerificationTasks
//             .Include(vt => vt.Candidate)
//             .ToList();

//         return View(verificationTasks);
//     }
// }
public IActionResult Index(int? candidateId)
{
    var verificationTasksQuery = _context.VerificationTasks.AsQueryable(); // Cast to IQueryable

    // Get list of candidates for dropdown
    ViewBag.Candidates = _context.Candidates.ToList();

    if (candidateId != null)
    {
        ViewBag.SelectedCandidateId = candidateId;

        // Filter tasks for the selected candidate
        verificationTasksQuery = verificationTasksQuery.Where(vt => vt.CandidateID == candidateId);
    }
    else
    {
        ViewBag.SelectedCandidateId = "All";
    }

    var verificationTasks = verificationTasksQuery.ToList();

    // Calculate counts based on the filtered tasks or all tasks
    ViewBag.TotalTasks = verificationTasks.Count();
    ViewBag.PendingTasks = verificationTasks.Count(vt => vt.Status == "Pending");
    ViewBag.OngoingTasks = verificationTasks.Count(vt => vt.Status == "Ongoing");
    ViewBag.CompletedTasks = verificationTasks.Count(vt => vt.Status == "Completed");

    return View(verificationTasks);
}

}
}
