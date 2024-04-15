using Microsoft.AspNetCore.Mvc;
using System.Linq;
using dotnetapp.Models;

namespace dotnetapp.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RestaurantController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Restaurant
        public IActionResult Index()
        {
            var restaurants = _context.Restaurants.ToList();
            return View(restaurants);
        }

        // GET: Restaurant/Create
        public IActionResult Create()
        {
            return View(new Restaurant());
        }

        // POST: Restaurant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(restaurant);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(restaurant);
        }
    }
}
