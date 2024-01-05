// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using dotnetapp.Models;
// using System.Collections.Generic;
// using System.Linq;

// namespace dotnetapp.Controllers
// {
//     public class VehicleController : Controller
//     {
//         private readonly ApplicationDbContext _context;

//         public VehicleController(ApplicationDbContext context)
//         {
//             _context = context;
//         }

//         public async Task<IActionResult> Index()
//         {
//             return View(await _context.Vehicles.ToListAsync());
//         }


//         // GET: Vehicle/Details/5
//         // GET: Vehicle/Details/5
//         public IActionResult Details(int? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }

//             var vehicle = _context.Vehicles.FirstOrDefault(m => m.VehicleId == id);
//             if (vehicle == null)
//             {
//                 return NotFound();
//             }

//             return View(vehicle);
//         }


//         // GET: Vehicle/Create
//         public IActionResult Create()
//         {
//             return View();
//         }

//         // POST: Vehicle/Create
//         // [HttpPost]
//         // [ValidateAntiForgeryToken]
//         // public IActionResult Create(Vehicle vehicle)
//         // {
//         //     if (ModelState.IsValid)
//         //     {
//         //         _context.Vehicles.Add(vehicle);
//         //         _context.SaveChanges();

//         //         return RedirectToAction(nameof(Index));
//         //         // return RedirectToAction(nameof(Create));
//         //     }

//         //     return View(vehicle);
//         // }

//         [HttpPost]
// [ValidateAntiForgeryToken]
// public IActionResult Create(Vehicle vehicle)
// {
//     if (ModelState.IsValid)
//     {
//         _context.Vehicles.Add(vehicle);
//         _context.SaveChanges();

//         // Fetch the details of the newly added vehicle
//         var newVehicleDetails = _context.Vehicles.FirstOrDefault(v => v.VehicleId == vehicle.VehicleId);

//         if (newVehicleDetails != null)
//         {
//             // If details are found, pass them to the Index view
//             var allVehicles = _context.Vehicles.ToList();
//             return View("Index", allVehicles);
//         }
//     }

//     return View(vehicle);
// }

//         // GET: Vehicle/Edit/5
//         public IActionResult Edit(int? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }

//             var vehicle = _context.Vehicles.Find(id);
//             if (vehicle == null)
//             {
//                 return NotFound();
//             }

//             return View(vehicle);
//         }

//         // ... Other actions ...

//         // GET: Vehicle/Book/5
//         public IActionResult Book(int? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }

//             // Redirect to the Booking/Create action with the VehicleId as a route parameter
//             return RedirectToAction("Index", "Booking", new { vehicleId = id });
//         }

//         private bool VehicleExists(int id)
//         {
//             return _context.Vehicles.Any(e => e.VehicleId == id);
//         }


//     }
// }



using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;
using System.Linq;

namespace dotnetapp.Controllers
{
    public class VehicleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehicleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vehicle/Index
        public IActionResult Index()
        {
            var vehicles = _context.Vehicles.ToList(); 
            return View(vehicles);
        }

        // GET: Vehicle/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = _context.Vehicles.FirstOrDefault(m => m.VehicleId == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicle/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehicle/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Vehicles.Add(vehicle);
                _context.SaveChanges();

                // Store the new vehicle ID in TempData to display in the Index view
                TempData["NewVehicleId"] = vehicle.VehicleId;

                return RedirectToAction(nameof(Index));
            }

            return View(vehicle);
        }

        // GET: Vehicle/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = _context.Vehicles.Find(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicle/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Vehicle vehicle)
        {
            if (id != vehicle.VehicleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.VehicleId))
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
            return View(vehicle);
        }

        // GET: Vehicle/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = _context.Vehicles.FirstOrDefault(m => m.VehicleId == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var vehicle = _context.Vehicles.Find(id);
            _context.Vehicles.Remove(vehicle);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicles.Any(e => e.VehicleId == id);
        }
    }
}
