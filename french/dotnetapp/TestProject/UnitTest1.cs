using dotnetapp.Controllers;
using dotnetapp.Exceptions;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;


namespace dotnetapp.Tests
{
    [TestFixture]
    public class BookingControllerTests
    {
        private ApplicationDbContext _context;
        private BookingController _controller;

        [SetUp]
        public void Setup()
        {
            // Set up the test database context
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _context = new ApplicationDbContext(options);
            _context.Database.EnsureCreated();

            _controller = new BookingController(_context);
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up the test database context
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

// Test if BatchEnrollmentForm action with valid BatchID redirects to EnrollmentConfirmation action with correct route values
[Test]
public void BatchEnrollmentForm_ValidBatchId_RedirectsToEnrollmentConfirmation()
{
    // Arrange
    // var batch = new Batch { BatchID = 100, StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1), Capacity = 5 };
    var batch = new Batch { BatchID = 100, StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1), Capacity = 5, Price = 100, Duration = 40 };
    _context.Batches.Add(batch);
    _context.Batches.Add(batch);
    _context.SaveChanges();

    var student = new Student { StudentID = 1, Name = "John Doe", Email = "john@example.com" };

    // Act
    var result = _controller.BatchEnrollmentForm(batch.BatchID, student) as RedirectToActionResult;

    // Assert
    Assert.IsNotNull(result);
    Assert.AreEqual("EnrollmentConfirmation", result.ActionName); // Ensure the correct action is redirected to
    Assert.AreEqual(student.StudentID, result.RouteValues["studentId"]); // Ensure correct studentId route value
}

//This test checks the invalid batchid returns the NotFoundresult or not
        [Test]
        public void BatchEnrollmentForm_InvalidBatchId_ReturnsNotFound()
        {
            // Arrange
            // var batch = new Batch { BatchID = 100, StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1), Capacity = 5 };
            var batch = new Batch { BatchID = 100, StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1), Capacity = 5, Price = 100, Duration = 40 };
    
            _context.Batches.Add(batch);

            // Act
            var result = _controller.BatchEnrollmentForm(batch.BatchID) as NotFoundResult;

            // Assert
            Assert.IsNotNull(result);
        }
// Test if BatchEnrollmentForm action with valid data creates a student and redirects to EnrollmentConfirmation
[Test]
public void BatchEnrollmentForm_ValidData_CreatesStudentAndRedirects()
{
    // Arrange
    // var batch = new Batch { BatchID = 100, StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1), Capacity = 1 };
    var batch = new Batch { BatchID = 100, StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1), Capacity = 5, Price = 100, Duration = 40 };

    _context.Batches.Add(batch);
    _context.SaveChanges();

    // Act
    var result = _controller.BatchEnrollmentForm(batch.BatchID, new Student { Name = "John Doe", Email = "john@example.com" }) as RedirectToActionResult;

    // Assert
    Assert.IsNotNull(result);
    Assert.AreEqual("EnrollmentConfirmation", result.ActionName);
}


//Checks the student valid data enrolled in BatchEnrollmentForm
        // Test if BatchEnrollmentForm action with valid data creates a student
[Test]
    public void BatchEnrollmentForm_ValidData_CreatesStudent()
    {
        // Arrange
        // var batch = new Batch { BatchID = 100, StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1), Capacity = 1 };
        var batch = new Batch { BatchID = 100, StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1), Capacity = 5, Price = 100, Duration = 40 };
        _context.Batches.Add(batch);
        _context.SaveChanges();

        // Act
        var result = _controller.BatchEnrollmentForm(batch.BatchID, new Student { Name = "John Doe", Email = "john@example.com" }) as RedirectToActionResult;

        // Assert
        // Check if the student was created and added to the database
        var student = _context.Students.SingleOrDefault(s => s.BatchID == batch.BatchID);
        Assert.IsNotNull(student);
        Assert.AreEqual("John Doe", student.Name);
        Assert.AreEqual("john@example.com", student.Email);
    }


// Test if BatchEnrollmentForm action throws SpanishTuitionBookingException after reaching capacity 0
[Test]
public void BatchEnrollmentForm_BatchFull_ThrowsException()
{
    // Arrange
    // var batch = new Batch { BatchID = 100, StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1), Capacity = 0 };
    var batch = new Batch { BatchID = 100, StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1), Capacity = 5, Price = 100, Duration = 40 };
    _context.Batches.Add(batch);
    _context.SaveChanges();

    // Act and Assert
    Assert.Throws<SpanishTuitionBookingException>(() =>
    {
        // Act
        _controller.BatchEnrollmentForm(batch.BatchID, new Student { Name = "John Doe", Email = "john@example.com" });
    });
}


//This test check the SpanishTuitionBookingException throws message - Maximum Number Reached or not
       // Test if BatchEnrollmentForm action throws SpanishTuitionBookingException with correct message after reaching capacity 0
[Test]
public void BatchEnrollmentForm_BatchFull_ThrowsException_with_message()
{
    // Arrange
    // var batch = new Batch { BatchID = 100, StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1), Capacity = 0 };
    var batch = new Batch { BatchID = 100, StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1), Capacity = 5, Price = 100, Duration = 40 };
    _context.Batches.Add(batch);
    _context.SaveChanges();

    // Act and Assert
    var exception = Assert.Throws<SpanishTuitionBookingException>(() =>
    {
        // Act
        _controller.BatchEnrollmentForm(batch.BatchID, new Student { Name = "John Doe", Email = "john@example.com" });
    });

    // Assert
    Assert.AreEqual("Maximum Number Reached", exception.Message);
}

    
//This test checks the student id non existent that redirects to NotFoundResult
        [Test]
        public void EnrollmentConfirmation_NonexistentStudentId_ReturnsNotFound()
        {
            // Arrange
            var studentId = 1;

            // Act
            var result = _controller.EnrollmentConfirmation(studentId) as NotFoundResult;

            // Assert
            Assert.IsNotNull(result);
        }

 //This test check the exists of Student class       
        [Test]
        public void StudentClassExists()
        {
            var student = new Student();
        
            Assert.IsNotNull(student);
        }

 //This test check the exists of Batch class        
        [Test]
        public void BatchClassExists()
        {
            var batch = new Batch();
        
            Assert.IsNotNull(batch);
        }
 
 //This test check the exists of ApplicationDbContext class has DbSet of Batches
 [Test]
        public void ApplicationDbContextContainsDbSetBatchProperty()
        {
            // using (var context = new ApplicationDbContext(_dbContextOptions))
            //         {
            // var context = new ApplicationDbContext();
        
            var propertyInfo = _context.GetType().GetProperty("Batches");
        
            Assert.IsNotNull(propertyInfo);
            Assert.AreEqual(typeof(DbSet<Batch>), propertyInfo.PropertyType);
                    // }
        }
 //This test check the exists of ApplicationDbContext class has DbSet of Students
        [Test]
        public void ApplicationDbContextContainsDbSetStudentProperty()
        {
            // using (var context = new ApplicationDbContext(_dbContextOptions))
            //         {
            // var context = new ApplicationDbContext();
        
            var propertyInfo = _context.GetType().GetProperty("Students");
        
            Assert.IsNotNull(propertyInfo);
            Assert.AreEqual(typeof(DbSet<Student>), propertyInfo.PropertyType);
        }
//This test check the BatchID of Batch class property is int
        [Test]
        public void Batch_Properties_BatchID_ReturnExpectedDataTypes()
        {
            // Arrange
            Batch batch = new Batch();
            Assert.That(batch.BatchID, Is.TypeOf<int>());
        }
//This test check the StartTime of Batch class property is DateTime
        [Test]
        public void Batch_Properties_StartTime_ReturnExpectedDataTypes()
        {
            // Arrange
            Batch batch = new Batch();
            Assert.That(batch.StartTime, Is.TypeOf<DateTime>());
        }

//This test check the EndTime of Batch class property is DateTime
        [Test]
        public void Batch_Properties_EndTime_ReturnExpectedDataTypes()
        {
            // Arrange
            Batch batch = new Batch();            
            Assert.That(batch.EndTime, Is.TypeOf<DateTime>());
        }
//This test check the Capacity of Batch class property is int
        [Test]
        public void Batch_Properties_Capacity_ReturnExpectedDataTypes()
        {
            // Arrange
            Batch batch = new Batch();
            Assert.That(batch.Capacity, Is.TypeOf<int>());
        }

//This test checks the expected value of BatchID
        [Test]
        public void Batch_Properties_BatchID_ReturnExpectedValues()
        {
            // Arrange
            int expectedBatchID = 100;

            Batch batch = new Batch
            {
                BatchID = expectedBatchID
            };
            Assert.AreEqual(expectedBatchID, batch.BatchID);
        }
//This test checks the expected value of StartTime
        [Test]
        public void Batch_Properties_StartTime_ReturnExpectedValues()
        {
            DateTime expectedStartTime = new DateTime(2023, 7, 1, 9, 0, 0);

            Batch batch = new Batch
            {
                StartTime = expectedStartTime
            };
            Assert.AreEqual(expectedStartTime, batch.StartTime);
        }
//This test checks the expected value of EndTime
        [Test]
        public void Batch_Properties_EndTime_ReturnExpectedValues()
        {
            DateTime expectedEndTime = new DateTime(2023, 7, 1, 10, 30, 0);

            Batch batch = new Batch
            {
                EndTime = expectedEndTime
            };
            Assert.AreEqual(expectedEndTime, batch.EndTime);
        }
//This test checks the expected value of Capacity
        [Test]
        public void Batch_Properties_Capacity_ReturnExpectedValues()
        {
            int expectedCapacity = 5;
            Batch batch = new Batch
            {
                Capacity = expectedCapacity
            };
            Assert.AreEqual(expectedCapacity, batch.Capacity);
        }
//This test checks the expected value of StudentID in Student class is int
        [Test]
        public void Student_Properties_StudentID_ReturnExpectedDataTypes()
        {
            // Arrange
            Student student = new Student();
            Assert.That(student.StudentID, Is.TypeOf<int>());
        }
//This test checks the expected value of Name in Student class is string
        [Test]
        public void Student_Properties_Name_ReturnExpectedDataTypes()
        {
            Student student = new Student();
            student.Name = "";
            Assert.That(student.Name, Is.TypeOf<string>());
        }
//This test checks the expected value of Email in Student class is string
        [Test]
        public void Student_Properties_Email_ReturnExpectedDataTypes()
        {
            // Arrange
            Student student = new Student();
            student.Email = "";
            Assert.That(student.Email, Is.TypeOf<string>());
        }
//This test checks the expected value of BatchID in Student class is int
        [Test]
        public void Student_Properties_BatchID_ReturnExpectedDataTypes()
        {
            // Arrange
            Student student = new Student();
            Assert.That(student.BatchID, Is.TypeOf<int>());
        }
//This test checks the expected value of Email in Student class is string
        [Test]
        public void Student_Properties_Email_ReturnExpectedValues()
        {
            string expectedEmail = "john@example.com";

            Student student = new Student
            {
                Email = expectedEmail
            };
            Assert.AreEqual(expectedEmail, student.Email);
        }
//This test checks the expected value of Batch in Student class is another entity Batch
        [Test]
        public void Student_Properties_Returns_Batch_ExpectedValues()
        {
            Batch expectedBatch = new Batch();

            Student student = new Student
            {
                Batch = expectedBatch
            };
            Assert.AreEqual(expectedBatch, student.Batch);
        }

        [Test]
        public void DeleteBatch_ValidBatchId_RemovesBatchFromDatabase()
        {
            // Arrange
            // var batch = new Batch { BatchID = 100, StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1), Capacity = 5 };
            var batch = new Batch { BatchID = 100, StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1), Capacity = 5, Price = 100, Duration = 40 };
            _context.Batches.Add(batch);
            _context.SaveChanges();
            var controller = new BatchController(_context);
            string methodName = "DeleteBatch";
            
            // Get the method info for the method name
            var methodInfo = typeof(BatchController).GetMethod(methodName);

            // Act
            var result = methodInfo.Invoke(controller, new object[] { batch.BatchID }) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("AvailableBatches", result.ActionName);

            // Check if the batch was removed from the database
            var deletedBatch = _context.Batches.Find(batch.BatchID);
            Assert.IsNull(deletedBatch);
        }
    }
}

