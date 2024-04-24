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

        public IActionResult ClassEnrollmentForm(int classid)
{
    var selectedClass = _context.Classes.Find(classid);
    Console.WriteLine(selectedClass);
    var selectedClass1 = _context.Classes
            .Include(c => c.Students)
            .FirstOrDefault(c => c.ClassID == classid);

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

    // Pass the selected class ID to the view to maintain context
    ViewBag.ClassId = classid;

    // Return the ClassEnrollmentForm view
    return View();
    return View("ClassEnrollmentForm", selectedClass);
}


        [HttpPost]
        public IActionResult ClassEnrollmentForm(int classid, Student student)
        {
            try
            {
                    Console.WriteLine("hai17"+ classid);
                
                if(!ModelState.IsValid){
                    Console.WriteLine("hai3");
                    
                    return View(student);
                }
                var selectedClass = _context.Classes
                    .Include(c => c.Students)
                    .FirstOrDefault(c => c.ClassID == classid);

                if (selectedClass == null)
                {
                    Console.WriteLine("hai4");

                    return NotFound(); // Handle class not found
                }

                if (selectedClass.Students.Count >= selectedClass.Capacity)
                {
                    throw new GuitarClassBookingException("Class is fully booked.");
                }
                    Console.WriteLine("hai2");

                if (ModelState.IsValid)
                {
                    Console.WriteLine("hai");
                    student.ClassID = classid; // Assign the class ID
                    _context.Students.Add(student);
                    _context.SaveChanges();

                    return RedirectToAction("EnrollmentConfirmation", new { studentId = student.StudentID });
                }
                return View(student);
            }
            catch (GuitarClassBookingException ex)
            {
                throw;
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            catch (Exception ex)
            {
                    Console.WriteLine("hai10");
                
                // Handle other exceptions here, such as database errors
                ModelState.AddModelError(string.Empty, "An error occurred while processing your request.");
            }

            // If the control reaches here, it means there are validation errors or other exceptions
            // var selectedClassForView = _context.Classes.Find(id);
            return View(student);
        }

        public IActionResult EnrollmentConfirmation(int studentId)
        {
            var enrolledStudent = _context.Students
                .Include(s => s.Class)
                .FirstOrDefault(s => s.StudentID == studentId);

            if (enrolledStudent == null)
            {
                return NotFound(); // Handle student not found
            }

            return View(enrolledStudent);
        }
    }
}
