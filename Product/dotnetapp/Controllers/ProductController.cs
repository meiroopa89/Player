using Microsoft.AspNetCore.Mvc;
using dotnetapp.Models;

namespace dotnetapp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductController(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Add(product);
                _db.SaveChanges();
                return RedirectToAction("View", new { id = product.Id });
            }
            return View(product);
        }

        // GET: Product/View
        public ActionResult View()
        {

            // Retrieve all products and pass them to the view
            var products = _db.Products.ToList();
            return View(products);
        }

    }
}
