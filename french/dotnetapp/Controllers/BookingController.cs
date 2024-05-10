using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Exceptions; 
using dotnetapp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapp.Controllers
{
public class BookingController : Controller
{
    private readonly ApplicationDbContext _context;

    public BookingController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult BatchEnrollmentForm(int id)
    {
        var batch = _context.Batches.Find(id);
        if (batch == null)
        {
            return NotFound();
        }
        return View(); // No model is passed to the view
    }

    [HttpPost]
    public IActionResult BatchEnrollmentForm(int id, Student student)
    {
        var batch = _context.Batches.Find(id);
        if (batch == null)
        {
            return NotFound();
        }
        student.BatchID = id;
        if (batch.Capacity == 0)
        {
            throw new SpanishTuitionBookingException("Maximum Number Reached");
        }

        if (!ModelState.IsValid)
        {
            return View(student);
        }
        
        _context.Students.Add(student);
        batch.Capacity = batch.Capacity - 1;
        _context.SaveChanges();

        // Redirect to EnrollmentConfirmation action
        return RedirectToAction("EnrollmentConfirmation", new { studentId = student.StudentID });
    }

    public IActionResult EnrollmentConfirmation(int studentId)
    {
        var student = _context.Students.Include(s => s.Batch).SingleOrDefault(s => s.StudentID == studentId);
        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }
}
}