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

        public IActionResult DeleteConfirm(int id)
        {
            var guitarClass = _context.Classes.Include(c => c.Students).FirstOrDefault(c => c.ClassID == id);
            if (guitarClass == null)
            {
                return NotFound();
            }

            return View(guitarClass);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var guitarClass = _context.Classes.Find(id);
            if (guitarClass == null)
            {
                return NotFound();
            }

            _context.Classes.Remove(guitarClass);
            _context.SaveChanges();

            return RedirectToAction(nameof(AvailableClasses));
        }


    }
}
