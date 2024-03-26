using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using dotnetapp.Models;

namespace dotnetapp.Controllers
{
    public class BookController : Controller
    {
        private readonly BookDbContext _context;

        public BookController(BookDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Book> books = _context.Books.ToList();
            int totalCount = _context.Books.Count();
            ViewBag.TotalCount = totalCount;
            return View(books);
        }
        public IActionResult Search(string searchString)
        {
            List<Book> books;
            if (string.IsNullOrEmpty(searchString))
            {
                // If search string is null or empty, display all books
                books = _context.Books.ToList();
                // return View("Index", books);
            }
            else
            {
                // Search books by title
                books = _context.Books
                    .Where(b => b.Title.Contains(searchString))
                    .ToList();

                // return View("Index", books);
            }
            int resultCount = books.Count;
            ViewBag.TotalCount = resultCount;
            return View("Index", books);

        }

        // public IActionResult Index()
        // {
        //     int totalCount = _context.Books.Count();
        //     Console.WriteLine("cpnt:"+_context.Books.Count());
        //     ViewBag.TotalCount = totalCount;
        //     return View(); // Assuming this is the view you provided
        // }

    }
}
