using System;
using System.Linq;
using GuitarBookingSystem.Data;
using GuitarBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuitarBookingSystem.Controllers
{
    public class ClassController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClassController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult AvailableClasses()
        {
            var availableClasses = _context.Classes
                .Include(c => c.Students)
                .Where(c => c.Students.Count < c.Capacity)
                .ToList();
            Console.WriteLine(availableClasses.Count);


            return View(availableClasses);
        }

        public IActionResult BookedClasses()
        {
            // Retrieve booked classes for the student and display them in the view
            return View();
        }

        [HttpPost]
        public IActionResult DeleteClass(int id)
        {
            // Find the class by its ID
            var classToDelete = _context.Classes.Find(id);

            if (classToDelete == null)
            {
                return NotFound(); // Return 404 if the class is not found
            }

            try
            {
                _context.Classes.Remove(classToDelete); // Remove the class
                _context.SaveChanges(); // Save changes to the database
                return RedirectToAction("AvailableClasses"); // Redirect to the available classes page
            }
            catch (Exception)
            {
                // Handle any exceptions that may occur during deletion
                return BadRequest(); // Return a bad request status code
            }
        }
    }
}
