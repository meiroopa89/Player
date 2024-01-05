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

    public IActionResult NewTask(int candidateId)
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

    // POST: /Verification/CreateTask
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateTask(VerificationTask verificationTask)
    {
        if (!ModelState.IsValid)
        {
            // Handle validation errors and display user-friendly messages
            return View("NewTask", verificationTask);
        }

        try
        {
            _context.VerificationTasks.Add(verificationTask);
            _context.SaveChanges();
            return RedirectToAction("Index", "Dashboard"); // Redirect to dashboard or specific page
        }
        catch (Exception ex)
        {
            // Log the exception for further investigation
            // Provide a user-friendly error message or redirect to an error page
            return RedirectToAction("Error", "Home");
        }
    }
}
}
