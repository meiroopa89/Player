using System.Collections.Generic;
using System.Linq;
using dotnetapp.Controllers;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;


namespace dotnetapp.TestProject
{

public class TestProject
{

        private ApplicationDbContext _context;
        private BookingController _controller;
        private SlotController _slotcontroller;

        
    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _context = new ApplicationDbContext(options);
            _context.Database.EnsureCreated();

            _controller = new BookingController(_context);
            _slotcontroller = new SlotController(_context);

            
    }

    [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

    [Test]
        public void Index_ReturnsViewWithBookings()
        {
            var bookings = new List<Booking>
            {
                new Booking { Slot = new Slot() },
                new Booking { Slot = new Slot() }
            };
            _context.Bookings.AddRange(bookings);
            _context.SaveChanges();

            var result = _controller.Index() as ViewResult;
            Console.WriteLine(bookings.Count);
            Assert.IsNotNull(result);
            Assert.AreEqual(bookings.Count, (result.Model as List<Booking>)?.Count);
        }

     
}
}