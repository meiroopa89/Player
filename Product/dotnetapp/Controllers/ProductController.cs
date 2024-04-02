using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using dotnetapp.Models;

namespace dotnetapp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductController(DbContextOptions<ApplicationDbContext> options)
        {
            _db = new ApplicationDbContext(options);
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

        // // GET: Product/View
        // public ActionResult View(int id)
        // {
        //     var product = _db.Products.Find(id);
        //     if (product == null)
        //     {
        //         return NotFound();
        //     }
        //     return View(product);
        // }

        // GET: Product/View
    public ActionResult View()
    {
        // Retrieve all products and pass them to the view
        var products = _db.Products.ToList();
        return View(products);
    }


    }
}
