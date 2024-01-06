using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
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

    // public IActionResult Create(){
    //     return View();
    // }

    public IActionResult Create()
{
        List<Candidate> candidates = _context.Candidates.ToList();

    ViewBag.Candidates = new SelectList(candidates, "CandidateID", "CandidateName");

    return View();
}

    // // POST: /Verification/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(VerificationTask verificationTask)
    {
        //     Console.WriteLine(verificationTask.Status);
        // if (!ModelState.IsValid)
        // {
        //     // Handle validation errors and display user-friendly messages
        //     return View("Task", verificationTask);
        // }

        try
        {
            
            // Console.WriteLine(verificationTask);
            _context.VerificationTasks.Add(verificationTask);
            _context.SaveChanges();
            return RedirectToAction("Index", "Verification"); 
        }
        catch (Exception ex)
        {
            return RedirectToAction("Error", "Home");
        }
    }

public IActionResult Index(int? candidateId)
{
    var verificationTasksQuery = _context.VerificationTasks.AsQueryable(); // Cast to IQueryable

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

    // Populate ViewBag.Candidates with data from your database
    ViewBag.Candidates = _context.Candidates.ToList(); // Adjust this to fetch your candidates from the database

    return View(verificationTasks);
}

// GET: Edit
public async Task<IActionResult> Edit(int? id)
{
    if (id == null)
    {
        return NotFound();
    }

    var verificationTask = await _context.VerificationTasks.FindAsync(id);
    if (verificationTask == null)
    {
        return NotFound();
    }
    return View(verificationTask);
}

// POST: Edit
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, VerificationTask verificationTask)
{
    if (id != verificationTask.TaskID)
    {
        return NotFound();
    }

    if (ModelState.IsValid)
    {
        try
        {
            _context.Update(verificationTask);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VerificationTaskExists(verificationTask.TaskID))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return RedirectToAction(nameof(Index));
    }
    return View(verificationTask);
}

// GET: Delete
public async Task<IActionResult> Delete(int? id)
{
    if (id == null)
    {
        return NotFound();
    }

    var verificationTask = await _context.VerificationTasks.FirstOrDefaultAsync(m => m.TaskID == id);
    if (verificationTask == null)
    {
        return NotFound();
    }

    return View("Delete", verificationTask);
}

// POST: Delete
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    var verificationTask = await _context.VerificationTasks.FindAsync(id);
    if (verificationTask != null)
    {
        _context.VerificationTasks.Remove(verificationTask);
        await _context.SaveChangesAsync();
    }

    return RedirectToAction(nameof(Index));
}

private bool VerificationTaskExists(int id)
{
    return _context.VerificationTasks.Any(e => e.TaskID == id);
}


}
}
