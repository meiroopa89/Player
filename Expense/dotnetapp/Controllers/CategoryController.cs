using Microsoft.AspNetCore.Mvc;
using dotnetapp.Models;

namespace dotnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CategoryController : Controller
{
    private readonly ApplicationDbContext _context;

    public CategoryController(ApplicationDbContext context)
    {
        _context = context;
    }


[HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                // Save the new category to the database
                _context.Categories.Add(category);
                _context.SaveChanges();

                // Redirect to the Index page
                // return RedirectToAction("Index", "Verification");
                return RedirectToAction("Index", "Category");
            }

            return View(category);
        }


    // GET: Category/Index
    public IActionResult Index()
    {
        var categories = _context.Categories.ToList();
        return View(categories);
    }
}

}
