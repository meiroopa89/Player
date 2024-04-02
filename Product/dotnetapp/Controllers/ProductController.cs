using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using dotnetapp.Models;

namespace dotnetapp.Controllers
{
public class ProductController : Controller
{
    private ApplicationDbContext db = new ApplicationDbContext();

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
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("View", new { id = product.Id });
        }
        return View(product);
    }

    // GET: Product/View
    public ActionResult View(int id)
    {
        var product = db.Products.Find(id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

}
}
