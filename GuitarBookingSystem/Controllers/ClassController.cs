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

        // GET: /Class/ClassEnrollmentForm/5
        public IActionResult ClassEnrollmentForm(int id)
        {
            // Fetch the class based on the provided ID
            var selectedClass = _context.Classes.Find(id);

            if (selectedClass == null)
            {
                return NotFound(); // Handle class not found
            }

            return View(selectedClass); // Return the view with the selected class
        }

        // POST: /Class/ClassEnrollmentForm/5
        [HttpPost]
        public IActionResult ClassEnrollmentForm(int id, Student student)
        {
            try
            {
                var selectedClass = _context.Classes
                    .Include(c => c.Students)
                    .FirstOrDefault(c => c.ClassID == id);

                if (selectedClass == null)
                {
                    return NotFound(); // Handle class not found
                }

                if (selectedClass.Students.Count >= selectedClass.Capacity)
                {
                    throw new GuitarClassBookingException("Class is fully booked.");
                }

                student.ClassID = id;

                if (ModelState.IsValid)
                {
                    _context.Students.Add(student);
                    _context.SaveChanges();

                   return RedirectToAction("ClassEnrollmentForm", "Booking", new { studentId = student.StudentID });
                }
            }
            catch (GuitarClassBookingException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while processing your request.");
            }

            // If the control reaches here, it means there are validation errors
            var selectedClassForView = _context.Classes.Find(id);
            return View(selectedClassForView);
        }

        // GET: /Class/EnrollmentConfirmation/5
        public IActionResult EnrollmentConfirmation(int studentId)
        {
            var enrolledStudent = _context.Students.Include(s => s.Class).FirstOrDefault(s => s.StudentID == studentId);

            if (enrolledStudent == null)
            {
                return NotFound(); // Handle student not found
            }

            return View(enrolledStudent);
        }
    }
}
