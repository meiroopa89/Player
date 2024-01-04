using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapp.Controllers
{
//     public class BookingController : Controller
// {
//     private readonly ApplicationDbContext _context;

//     public BookingController(ApplicationDbContext context)
//     {
//         _context = context;
//     }

//     // GET: /Booking/Delete/5
//     public IActionResult Delete(int? id)
//     {
//         if (id == null)
//         {
//             return NotFound();
//         }

//         var booking = _context.Bookings.FirstOrDefault(m => m.BookingId == id);
//         if (booking == null)
//         {
//             return NotFound();
//         }

//         return View(booking);
//     }

//     // POST: /Booking/Delete/5
//     [HttpPost, ActionName("Delete")]
//     [ValidateAntiForgeryToken]
//     public IActionResult DeleteConfirmed(int id)
//     {
//         var booking = _context.Bookings.Find(id);
//         if (booking == null)
//         {
//             return NotFound();
//         }

//         _context.Bookings.Remove(booking);
//         _context.SaveChanges();

//         return RedirectToAction(nameof(Index));
//     }

//     // GET: /Booking/Create
//     public IActionResult Create()
//     {
//         return View();
//     }

//     // POST: /Booking/Create
//     [HttpPost]
//     [ValidateAntiForgeryToken]
//     public IActionResult Create(Booking booking)
//     {
//         if (ModelState.IsValid)
//         {
//             // Save the booking to the database
//             _context.Bookings.Add(booking);
//             _context.SaveChanges();
            
//             return RedirectToAction(nameof(Index));
//         }
        
//         return View(booking);
//     }

//     public IActionResult Create(Vehicle vehicle)
// {
//     if (ModelState.IsValid)
//     {
//         // Logic to save the vehicle details to the database goes here

//         // Redirect to the Booking/Create action after successful submission
//         return RedirectToAction("Create", "Booking"); // Replace "Create" with the appropriate action in your BookingController
//     }

//     return View(vehicle);
// }

//     // GET: /Booking/Details/5
//     public IActionResult Details(int? id)
//     {
//         if (id == null)
//         {
//             return NotFound();
//         }

//         var booking = _context.Bookings.FirstOrDefault(m => m.BookingId == id);
//         if (booking == null)
//         {
//             return NotFound();
//         }

//         return View(booking);
//     }

//     public IActionResult Edit(int? id)
//     {
//         if (id == null)
//         {
//             return NotFound();
//         }

//         var booking = _context.Bookings.Find(id);
//         if (booking == null)
//         {
//             return NotFound();
//         }

//         return View(booking);
//     }

//     // POST: /Booking/Edit/5
//     [HttpPost]
//     [ValidateAntiForgeryToken]
//     public IActionResult Edit(int id, Booking booking)
//     {
//         if (id != booking.BookingId)
//         {
//             return NotFound();
//         }

//         if (ModelState.IsValid)
//         {
//             try
//             {
//                 _context.Update(booking);
//                 _context.SaveChanges();
//             }
//             catch (DbUpdateConcurrencyException)
//             {
//                 if (!BookingExists(booking.BookingId))
//                 {
//                     return NotFound();
//                 }
//                 else
//                 {
//                     throw;
//                 }
//             }
//             return RedirectToAction(nameof(Index));
//         }
//         return View(booking);
//     }

//     // GET: /Booking/Index
//     public IActionResult Index()
//     {
//         var bookings = _context.Bookings.ToList();
//         return View(bookings);
//     }

//     // Other actions like Create, Details, Delete, etc.

//     private bool BookingExists(int id)
//     {
//         return _context.Bookings.Any(e => e.BookingId == id);
//     }

// }

// }




public class BookingController : Controller
{
    private readonly ApplicationDbContext _context;

    public BookingController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Existing actions...

    // GET: Booking/Edit/5
    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var booking = _context.Bookings.FirstOrDefault(m => m.BookingId == id);
        if (booking == null)
        {
            return NotFound();
        }

        return View(booking);
    }

    // POST: Booking/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Booking booking)
    {
        if (id != booking.BookingId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _context.Update(booking);
            _context.SaveChanges();

            return RedirectToAction("Index", "Booking");
        }

        return View(booking);
    }

    // GET: Booking/Delete/5
    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var booking = _context.Bookings.FirstOrDefault(m => m.BookingId == id);
        if (booking == null)
        {
            return NotFound();
        }

        return View(booking);
    }

    // POST: Booking/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var booking = _context.Bookings.Find(id);
        if (booking == null)
        {
            return NotFound();
        }

        _context.Bookings.Remove(booking);
        _context.SaveChanges();

       return RedirectToAction("Index", "Booking");
    }
    
    // GET: /Booking/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Booking/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Booking booking)
    {
        if (ModelState.IsValid)
        {
            // Save the booking to the database
            _context.Bookings.Add(booking);
            _context.SaveChanges();
            
            // return RedirectToAction(nameof(Index));
            //   return RedirectToAction("Index", "Booking");
            return RedirectToAction("Details", new { id = booking.BookingId });
        }
        
        return View(booking);
    }

//     public IActionResult Create(Vehicle vehicle)
// {
//     if (ModelState.IsValid)
//     {
//        return RedirectToAction("Details", new { id = booking.BookingId });
//     }

//     return View(vehicle);
    }

}


