using System;
using GuitarBookingSystem.Data;
using GuitarBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuitarBookingSystem.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult ClassEnrollmentForm(int id)
        {
            var selectedClass = _context.Classes.Find(id);
            var selectedClass1 = _context.Classes
                    .Include(c => c.Students)
                    .FirstOrDefault(c => c.ClassID == id);

            Console.WriteLine(selectedClass1.Capacity);
            Console.WriteLine(selectedClass1.Students.Count);

            if (selectedClass1.Students.Count >= selectedClass1.Capacity)
            {
                throw new GuitarClassBookingException("Class is fully booked.");
            }

            if (selectedClass == null)
            {
                return NotFound(); // Handle class not found
            }

            return View(selectedClass);
        }

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

                    return RedirectToAction("EnrollmentConfirmation", new { studentId = student.StudentID });
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
