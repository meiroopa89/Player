// using Microsoft.AspNetCore.Mvc;
// using dotnetapp1.Models;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using dotnetapp1.Data;

// namespace dotnetapp1.Controllers
// {
//     public class BookController : Controller
//     {
//         private readonly ApplicationDbContext _context;

//         public BookController(ApplicationDbContext context)
//         {
//             _context = context;
//         }

//         public IActionResult Create()
//         {
//             return View();
//         }

//         [HttpPost]
//         public IActionResult Create(Book newBook)
//         {
//             try
//             {
//                 if (ModelState.IsValid)
//                 {
//                     _context.Add(newBook);
//                     _context.SaveChanges();

//                     return RedirectToAction("Index");
//                 }
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message);
//             }

//             return View(newBook);
//         }

//         public IActionResult Index()
//         {
//             List<Book> bookList = _context.Books.ToList();
//             return View(bookList);
//         }

//         [HttpPost]
//         public IActionResult Delete(int id)
//         {
//             var bookToDelete = _context.Books.Find(id);

//             if (bookToDelete != null)
//             {
//                 _context.Books.Remove(bookToDelete);
//                 _context.SaveChanges();
//             }

//             return RedirectToAction("Index");
//         }

//         [HttpGet]
//         public IActionResult Update(int id)
//         {
//             var bookToUpdate = _context.Books.Find(id);

//             if (bookToUpdate == null)
//             {
//                 return NotFound();
//             }

//             return View(bookToUpdate);
//         }

//         [HttpPost]
//         public IActionResult Update(Book updatedBook)
//         {
//             try
//             {
//                 if (ModelState.IsValid)
//                 {
//                     _context.Update(updatedBook);
//                     _context.SaveChanges();

//                     return RedirectToAction("Index");
//                 }
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message);
//             }

//             return View(updatedBook);
//         }
//     }
// }



using Microsoft.AspNetCore.Mvc;
using dotnetapp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using dotnetapp1.Data;

namespace dotnetapp1.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book newBook)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(newBook);
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return View(newBook);
        }

        public IActionResult Index()
        {
            List<Book> bookList = _context.Books.ToList();
            return View(bookList);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var bookToDelete = _context.Books.Find(id);

            if (bookToDelete != null)
            {
                _context.Books.Remove(bookToDelete);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var bookToUpdate = _context.Books.Find(id);

            if (bookToUpdate == null)
            {
                return NotFound();
            }

            return View(bookToUpdate);
        }

        [HttpPost]
        public IActionResult Update(Book updatedBook)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Update(updatedBook);
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return View(updatedBook);
        }
    }
}
