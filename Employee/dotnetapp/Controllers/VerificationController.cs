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

    // POST: /Verification/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(VerificationTask verificationTask)
    {
            Console.WriteLine(verificationTask.Status);
        // if (!ModelState.IsValid)
        // {
        //     // Handle validation errors and display user-friendly messages
        //     return View("Task", verificationTask);
        // }

        try
        {
            verificationTask.CandidateID = 3;
            
            Console.WriteLine(verificationTask);
            _context.VerificationTasks.Add(verificationTask);
            _context.SaveChanges();
            return RedirectToAction("Index", "Verification"); 
        }
        catch (Exception ex)
        {
            return RedirectToAction("Error", "Home");
        }
    }
    // public IActionResult Index()
    // {
    //     var verificationTasks = _context.VerificationTasks.Include(vt => vt.Candidate).ToList();
    //     return View(verificationTasks); 
    // }

    public IActionResult Index()
        {
            var verificationTasks = _context.VerificationTasks.Include(vt => vt.Candidate).ToList();

            var tasksByCandidate = verificationTasks
                .GroupBy(vt => vt.Candidate.CandidateName)
                .Select(g => new
                {
                    CandidateName = g.Key,
                    TotalTasks = g.Count(),
                    PendingTasks = g.Count(t => t.Status == "Pending"),
                    OngoingTasks = g.Count(t => t.Status == "Ongoing"),
                    CompletedTasks = g.Count(t => t.Status == "Completed")
                }).ToList();

            ViewBag.TasksByCandidate = tasksByCandidate;

            return View();
        }

}
}
