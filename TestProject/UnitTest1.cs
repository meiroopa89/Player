// namespace TestProject;

// public class Tests
// {
//     [SetUp]
//     public void Setup()
//     {
//     }

//     [Test]
//     public void Test1()
//     {
//         Assert.Pass();
//     }
// }


using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GuitarBookingSystem.Controllers;
using GuitarBookingSystem.Data;
using GuitarBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;


namespace GuitarBookingSystem.Tests
{
    [TestFixture]
    public class GuitarBookingSystemTest
    {
        private DbContextOptions<ApplicationDbContext> _dbContextOptions;

        [SetUp]
        public void Setup()
        {
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var dbContext = new ApplicationDbContext(_dbContextOptions))
            {
                // Add test data to the in-memory database
                var ride = new Class
                {
                    ClassID = 1,
                    StartTime = DateTime.Parse("2023-08-30"),
                    EndTime = DateTime.Parse("2023-09-30"),
                    Capacity = 1
                };

                dbContext.Classes.Add(ride);
                dbContext.SaveChanges();
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var dbContext = new ApplicationDbContext(_dbContextOptions))
            {
                // Clear the in-memory database after each test
                dbContext.Database.EnsureDeleted();
            }
        }

        
        [Test]
        public void ClassEnrollmentForm_ValidStudent_JoinsSuccessfully_ClassTable()
        {
            using (var dbContext = new ApplicationDbContext(_dbContextOptions))
            {
                // Arrange
                var controllerType = typeof(BookingController);
                var controller = Activator.CreateInstance(controllerType, dbContext);

                // Specify the method signature (parameter types)
                MethodInfo method = controllerType.GetMethod("ClassEnrollmentForm", new[] { typeof(int), typeof(string), typeof(string) });

                var student = new Student
                {
                    Name = "John Doe",
                    Email = "johndoe@example.com",
                };

                // Act
                var result = method.Invoke(controller, new object[] { 1, "John Doe", "johndoe@example.com" }) as RedirectToActionResult;

                // Assert
                Assert.IsNotNull(result);

                var ride = dbContext.Classes.Include(r => r.Students).FirstOrDefault(r => r.ClassID == 1);
                Assert.IsNotNull(ride);
                Assert.AreEqual(1, ride.Students.Count);
            }
        }

        [Test]
        public void ClassEnrollmentForm_ValidStudent_JoinsSuccessfully_StudentTable()
        {
            using (var dbContext = new ApplicationDbContext(_dbContextOptions))
            {
                // Arrange
                var controllerType = typeof(BookingController);
                var controller = Activator.CreateInstance(controllerType, dbContext);

                // Specify the method signature (parameter types)
                MethodInfo method = controllerType.GetMethod("ClassEnrollmentForm", new[] { typeof(int), typeof(string), typeof(string) });

                var student = new Student
                {
                    Name = "John Doe",
                    Email = "johndoe@example.com",
                };

                // Act
                var result = method.Invoke(controller, new object[] { 1, "John Doe", "johndoe@example.com" }) as RedirectToActionResult;

                var ride = dbContext.Students.FirstOrDefault(r => r.StudentID == 1);
                Assert.IsNotNull(ride);
                Assert.AreEqual(1, ride.StudentID);
            }
        }

        [Test]
        public void ClassEnrollmentForm_ValidStudent_JoinsSuccessfully_StudentTable1()
        {
            using (var dbContext = new ApplicationDbContext(_dbContextOptions))
            {
                // Arrange
                var controllerType = typeof(BookingController);
                var controller = Activator.CreateInstance(controllerType, dbContext);

                // Specify the method signature (parameter types)
                MethodInfo method = controllerType.GetMethod("ClassEnrollmentForm", new[] { typeof(int), typeof(string), typeof(string) });

                var student = new Student
                {
                    Name = "John Doe",
                    Email = "johndoe@example.com",
                };

                // Act
                var result = method.Invoke(controller, new object[] { 1, "John Doe", "johndoe@example.com" }) as RedirectToActionResult;

                var ride = dbContext.Students.FirstOrDefault(r => r.StudentID == 1);
                Assert.IsNotNull(ride);
                Assert.AreEqual("John Doe", ride.Name);
                Assert.AreEqual("johndoe@example.com", ride.Email);
            }
        }

        [Test]
        public void ClassEnrollmentForm_Returns_EnrollmentConfirmation_Action()
        {
            using (var dbContext = new ApplicationDbContext(_dbContextOptions))
            {
                // Arrange
                var controllerType = typeof(BookingController);
                var controller = Activator.CreateInstance(controllerType, dbContext);

                // Specify the method signature (parameter types)
                MethodInfo method = controllerType.GetMethod("ClassEnrollmentForm", new[] { typeof(int), typeof(string), typeof(string) });

                var student = new Student
                {
                    Name = "John Doe",
                    Email = "johndoe@example.com",
                };

                // Act
                var result = method.Invoke(controller, new object[] { 1, "John Doe", "johndoe@example.com" }) as RedirectToActionResult;

                var ride = dbContext.Students.FirstOrDefault(r => r.StudentID == 1);

                Assert.IsNotNull(result);
                Assert.AreEqual("EnrollmentConfirmation", result.ActionName);
            }
        }

        [Test]
        public void EnrollmentConfirmation_InvalidID_Returns_NotFound()
        {
            using (var dbContext = new ApplicationDbContext(_dbContextOptions))
            {
                // Arrange
                var controllerType = typeof(BookingController);
                var controller = Activator.CreateInstance(controllerType, dbContext);

                // Specify the method signature (parameter types)
                MethodInfo method = controllerType.GetMethod("ClassEnrollmentForm", new[] { typeof(int), typeof(string), typeof(string) });

                MethodInfo method1 = controllerType.GetMethod("EnrollmentConfirmation", new[] { typeof(int) });

                var student = new Student
                {
                    Name = "John Doe",
                    Email = "johndoe@example.com",
                };

                // Act
                var result = method.Invoke(controller, new object[] { 1, "John Doe", "johndoe@example.com" });
                var result1 = method1.Invoke(controller, new object[] { 2 }) as NotFoundResult;

                var ride = dbContext.Students.FirstOrDefault(r => r.StudentID == 1);

                Assert.IsNotNull(result1);
                //Assert.AreEqual("EnrollmentConfirmation", result1.ActionName);
            }
        }


        [Test]
        public void EnrollmentConfirmation_validID_Returns_View()
        {
            using (var dbContext = new ApplicationDbContext(_dbContextOptions))
            {
                // Arrange
                var controllerType = typeof(BookingController);
                var controller = Activator.CreateInstance(controllerType, dbContext);

                // Specify the method signature (parameter types)
                MethodInfo method = controllerType.GetMethod("ClassEnrollmentForm", new[] { typeof(int), typeof(string), typeof(string) });

                MethodInfo method1 = controllerType.GetMethod("EnrollmentConfirmation", new[] { typeof(int) });

                var student = new Student
                {
                    Name = "John Doe",
                    Email = "johndoe@example.com",
                };

                // Act
                var result = method.Invoke(controller, new object[] { 1, "John Doe", "johndoe@example.com" });
                var result1 = method1.Invoke(controller, new object[] { 1 }) as ViewResult;

                var ride = dbContext.Students.FirstOrDefault(r => r.StudentID == 1);

                Assert.IsNotNull(result1);
            }
        }


        [Test]
        public void AvailableClasses_Method_Exists_ClassController()
        {
            using (var dbContext = new ApplicationDbContext(_dbContextOptions))
            {
                // Arrange
                var controllerType = typeof(ClassController);
                var controller = Activator.CreateInstance(controllerType, dbContext);

                // Specify the method signature (parameter types)
                MethodInfo method = controllerType.GetMethod("AvailableClasses");
                Assert.IsNotNull(method);
            }
        }

        [Test]
        public void ClassEnrollmentForm_Method_Exists_BookingController_1_parameter()
        {
            using (var dbContext = new ApplicationDbContext(_dbContextOptions))
            {
                // Arrange
                var controllerType = typeof(BookingController);
                var controller = Activator.CreateInstance(controllerType, dbContext);

                // Specify the method signature (parameter types)
                MethodInfo method = controllerType.GetMethod("ClassEnrollmentForm", new[] { typeof(int) });
                Assert.IsNotNull(method);
            }
        }

        [Test]
        public void ClassEnrollmentForm_Method_Exists_BookingController_3_parameter()
        {
            using (var dbContext = new ApplicationDbContext(_dbContextOptions))
            {
                // Arrange
                var controllerType = typeof(BookingController);
                var controller = Activator.CreateInstance(controllerType, dbContext);

                // Specify the method signature (parameter types)
                MethodInfo method = controllerType.GetMethod("ClassEnrollmentForm", new[] { typeof(int), typeof(string), typeof(string) });
                Assert.IsNotNull(method);
            }
        }

        [Test]
        public void EnrollmentConfirmation_Method_Exists_BookingController_1_parameter()
        {
            using (var dbContext = new ApplicationDbContext(_dbContextOptions))
            {
                // Arrange
                var controllerType = typeof(BookingController);
                var controller = Activator.CreateInstance(controllerType, dbContext);

                // Specify the method signature (parameter types)
                MethodInfo method = controllerType.GetMethod("EnrollmentConfirmation", new[] { typeof(int) });
                Assert.IsNotNull(method);
            }
        }
        
        [Test]
        public void ClassEnrollmentForm_ClassNotFound_ReturnsNotFoundResult()
        {
            using (var dbContext = new ApplicationDbContext(_dbContextOptions))
            {
                // Arrange
                var controllerType = typeof(BookingController);
                var controller = Activator.CreateInstance(controllerType, dbContext);

                // Specify the method signature (parameter types)
                MethodInfo method = controllerType.GetMethod("ClassEnrollmentForm", new[] { typeof(int), typeof(string), typeof(string) });

                var student = new Student
                {
                    Name = "John Doe",
                    Email = "johndoe@example.com",
                };

                // Act
                var result = method.Invoke(controller, new object[] { 2, "John Doe", "johndoe@example.com" }) as NotFoundResult;


                // Assert
                Assert.IsNotNull(result);
            }
        }
        [Test]
        public void ClassEnrollmentForm_ThrowsException_fullyBooked_Class()
        {
            using (var dbContext = new ApplicationDbContext(_dbContextOptions))
            {
                // Arrange
                var controllerType = typeof(BookingController);
                var controller = Activator.CreateInstance(controllerType, dbContext);

                MethodInfo method = controllerType.GetMethod("ClassEnrollmentForm", new[] { typeof(int), typeof(string), typeof(string) });

                // Act and Assert for the first scenario
                var student = new Student
                {
                    Name = "John Doe",
                    Email = "johndoe@example.com",
                };
                var result = method.Invoke(controller, new object[] { 1, "John Doe", "johndoe@example.com" }) as RedirectToActionResult;

                // Assert for the first scenario
                Assert.IsNotNull(result);

                // Act and Assert for the second scenario
                MethodInfo method1 = controllerType.GetMethod("ClassEnrollmentForm", new[] { typeof(int) });

                var exception = Assert.Throws<TargetInvocationException>(() =>
                {
                    method1.Invoke(controller, new object[] { 1 });
                });

                // Assert that the inner exception is of type GuitarClassBookingException
                Assert.IsInstanceOf<GuitarClassBookingException>(exception.InnerException);
            }
        }


        [Test]
        public void ClassEnrollmentForm_ThrowsException_fullyBooked_Class_With_Message()
        {
            using (var dbContext = new ApplicationDbContext(_dbContextOptions))
            {
                // Arrange
                var controllerType = typeof(BookingController);
                var controller = Activator.CreateInstance(controllerType, dbContext);

                MethodInfo method = controllerType.GetMethod("ClassEnrollmentForm", new[] { typeof(int), typeof(string), typeof(string) });

                // Act and Assert for the first scenario
                var student = new Student
                {
                    Name = "John Doe",
                    Email = "johndoe@example.com",
                };
                var result = method.Invoke(controller, new object[] { 1, "John Doe", "johndoe@example.com" }) as RedirectToActionResult;

                // Assert for the first scenario
                Assert.IsNotNull(result);

                // Act and Assert for the second scenario
                MethodInfo method1 = controllerType.GetMethod("ClassEnrollmentForm", new[] { typeof(int) });

                var exception = Assert.Throws<TargetInvocationException>(() =>
                {
                    method1.Invoke(controller, new object[] { 1 });
                });

                // Assert that the inner exception is of type GuitarClassBookingException
                Assert.IsInstanceOf<GuitarClassBookingException>(exception.InnerException);
                Assert.AreEqual("Class is fully booked.", exception.InnerException.Message);
            }
        }


        


        [Test]
        public void Class_ClassExists()
        {
                    string assemblyName = "GuitarBookingSystem"; 
                    string typeName = "GuitarBookingSystem.Models.Class";
                    Assembly assembly = Assembly.Load(assemblyName);
                    Type rideType = assembly.GetType(typeName);
                    Assert.IsNotNull(rideType);
                    var ride = Activator.CreateInstance(rideType);
                    Assert.IsNotNull(ride);
        }

        [Test]
        public void Student_ClassExists()
        {
            string assemblyName = "GuitarBookingSystem";
            string typeName = "GuitarBookingSystem.Models.Student";
            Assembly assembly = Assembly.Load(assemblyName);
            Type rideType = assembly.GetType(typeName);
            Assert.IsNotNull(rideType);
            var ride = Activator.CreateInstance(rideType);
            Assert.IsNotNull(ride);
        }
        [Test]
        public void GuitarBookingSystemException_ClassExists()
        {
            string assemblyName = "GuitarBookingSystem";
            string typeName = "GuitarBookingSystem.Models.GuitarClassBookingException";
            Assembly assembly = Assembly.Load(assemblyName);
            Type rideType = assembly.GetType(typeName);
            Assert.IsNotNull(rideType);
        }



        [Test]
        public void ApplicationDbContextContainsDbSetClassesProperty()
        {
            // var context = new ApplicationDbContext();
            using (var dbContext = new ApplicationDbContext(_dbContextOptions))
            {
                var propertyInfo = dbContext.GetType().GetProperty("Classes");

                Assert.IsNotNull(propertyInfo);
                Assert.AreEqual(typeof(DbSet<Class>), propertyInfo.PropertyType);
            }
        }

        [Test]
        public void ApplicationDbContextContainsDbSetStudentsProperty()
        {
            // var context = new ApplicationDbContext();
            using (var dbContext = new ApplicationDbContext(_dbContextOptions))
            {
                var propertyInfo = dbContext.GetType().GetProperty("Students");
                Assert.IsNotNull(propertyInfo);
                Assert.AreEqual(typeof(DbSet<Student>), propertyInfo.PropertyType);
            }
        }


        [Test]
        public void Class_Properties_ClassID_ReturnExpectedDataTypes_int()
        {
            string assemblyName = "GuitarBookingSystem";
            string typeName = "GuitarBookingSystem.Models.Class";
            Assembly assembly = Assembly.Load(assemblyName);
            Type commuterType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = commuterType.GetProperty("ClassID");
            Assert.IsNotNull(propertyInfo, "The property 'ClassID' was not found on the Commuter class.");
            Type propertyType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(int), propertyType, "The data type of 'ClassID' property is not as expected (int).");
        }

        [Test]
        public void Class_Properties_StartTime_ReturnExpectedDataTypes_DateTime()
        {
            string assemblyName = "GuitarBookingSystem";
            string typeName = "GuitarBookingSystem.Models.Class";
            Assembly assembly = Assembly.Load(assemblyName);
            Type commuterType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = commuterType.GetProperty("StartTime");
            Assert.IsNotNull(propertyInfo, "The property 'StartTime' was not found on the Commuter class.");
            Type propertyType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(DateTime), propertyType, "The data type of 'StartTime' property is not as expected (DateTime).");
        }
        [Test]
        public void Class_Properties_EndTime_ReturnExpectedDataTypes_DateTime()
        {
            string assemblyName = "GuitarBookingSystem";
            string typeName = "GuitarBookingSystem.Models.Class";
            Assembly assembly = Assembly.Load(assemblyName);
            Type commuterType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = commuterType.GetProperty("EndTime");
            Assert.IsNotNull(propertyInfo, "The property 'EndTime' was not found on the Commuter class.");
            Type propertyType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(DateTime), propertyType, "The data type of 'EndTime' property is not as expected (DateTime).");
        }

        [Test]
        public void Class_Properties_Students_ReturnExpectedDataTypes_Student()
        {
            string assemblyName = "GuitarBookingSystem";
            string typeName = "GuitarBookingSystem.Models.Class";
            Assembly assembly = Assembly.Load(assemblyName);
            Type commuterType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = commuterType.GetProperty("Students");
            Assert.IsNotNull(propertyInfo, "The property 'Students' was not found on the Commuter class.");
            Type propertyType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(ICollection<Student>), propertyType, "The data type of 'Students' property is not as expected (Student).");
        }

        [Test]
        public void Student_Properties_StudentID_ReturnExpectedDataTypes_int()
        {
            string assemblyName = "GuitarBookingSystem";
            string typeName = "GuitarBookingSystem.Models.Student";
            Assembly assembly = Assembly.Load(assemblyName);
            Type commuterType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = commuterType.GetProperty("StudentID");
            Assert.IsNotNull(propertyInfo, "The property 'StudentID' was not found on the Commuter class.");
            Type propertyType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(int), propertyType, "The data type of 'StudentID' property is not as expected (int).");
        }
        [Test]
        public void Student_Properties_Name_ReturnExpectedDataTypes_string()
        {
            string assemblyName = "GuitarBookingSystem";
            string typeName = "GuitarBookingSystem.Models.Student";
            Assembly assembly = Assembly.Load(assemblyName);
            Type commuterType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = commuterType.GetProperty("Name");
            Assert.IsNotNull(propertyInfo, "The property 'Name' was not found on the Commuter class.");
            Type propertyType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(string), propertyType, "The data type of 'Name' property is not as expected (string).");
        }
        [Test]
        public void Student_Properties_Email_ReturnExpectedDataTypes_string()
        {
            string assemblyName = "GuitarBookingSystem";
            string typeName = "GuitarBookingSystem.Models.Student";
            Assembly assembly = Assembly.Load(assemblyName);
            Type commuterType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = commuterType.GetProperty("Email");
            Assert.IsNotNull(propertyInfo, "The property 'Email' was not found on the Commuter class.");
            Type propertyType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(string), propertyType, "The data type of 'Email' property is not as expected (string).");
        }

        [Test]
        public void Student_Properties_ClassID_ReturnExpectedDataTypes_int()
        {
            string assemblyName = "GuitarBookingSystem";
            string typeName = "GuitarBookingSystem.Models.Student";
            Assembly assembly = Assembly.Load(assemblyName);
            Type commuterType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = commuterType.GetProperty("ClassID");
            Assert.IsNotNull(propertyInfo, "The property 'ClassID' was not found on the Student class.");
            Type propertyType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(int), propertyType, "The data type of 'ClassID' property is not as expected (int).");
        }

        [Test]
        public void Student_Properties_Class_ReturnExpectedDataTypes_Class()
        {
            string assemblyName = "GuitarBookingSystem";
            string typeName = "GuitarBookingSystem.Models.Student";
            Assembly assembly = Assembly.Load(assemblyName);
            Type commuterType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = commuterType.GetProperty("Class");
            Assert.IsNotNull(propertyInfo, "The property 'Class' was not found on the Student class.");
            Type propertyType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(Class), propertyType, "The data type of 'Class' property is not as expected (Class).");
        }

         [Test]
    public void DeleteClass_ValidClassId_RemovesClassFromDatabase()
    {
        using (var dbContext = new ApplicationDbContext(_dbContextOptions))
        {
            // Arrange
            var controllerType = typeof(ClassController);
            var controller = Activator.CreateInstance(controllerType, dbContext);

            // Specify the method signature (parameter types)
            MethodInfo method = controllerType.GetMethod("DeleteClass", new[] { typeof(int) });

            // Add a class to be deleted
            var classInstance = new Class
            {
                ClassID = 100,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(1),
                Capacity = 5
            };
            dbContext.Classes.Add(classInstance);
            dbContext.SaveChanges();

            // Act
            var result = method.Invoke(controller, new object[] { 100 }) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);

            var deletedClass = dbContext.Classes.Find(100);
            Assert.IsNull(deletedClass);
        }
    }


        
    }

}