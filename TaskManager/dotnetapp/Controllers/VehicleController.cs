using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;
using System.Collections.Generic;
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

        // ... Other actions ...

        // GET: Vehicle/Book/5
        public IActionResult Book(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Redirect to the Booking/Create action with the VehicleId as a route parameter
            return RedirectToAction("Create", "Booking", new { vehicleId = id });
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicles.Any(e => e.VehicleId == id);
        }


    }
}
