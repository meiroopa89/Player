using NUnit.Framework;
using dotnetapp.Controllers;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using Moq;
using System.Data;
using System.Data.SqlClient;


namespace BookControllerTests
{
    [TestFixture]
    public class BookControllerTests
    {
        private BookController _controller;
        private Type controllerType;
        private Type carserviceType;
        private PropertyInfo[] properties;

        [SetUp]
        public void Setup()
        {
            // Initialize the controller before each test
            _controller = new BookController();
            carserviceType = typeof(dotnetapp.Models.Book);
            properties = carserviceType.GetProperties();
            controllerType = typeof(BookController);
        }

        [Test]
        public void Test_IndexReturns_ViewResult()
        {
                string assemblyName = "dotnetapp";
                Assembly assembly = Assembly.Load(assemblyName);
                string controllerTypeName = "dotnetapp.Controllers.BookController";
                Type controllerType = assembly.GetType(controllerTypeName);
                MethodInfo method = controllerType.GetMethod("Index");
                Assert.IsNotNull(method);
                var controllerInstance = Activator.CreateInstance(controllerType);
                var result = method.Invoke(controllerInstance, null);
                Assert.IsNotNull(result);
                Assert.IsInstanceOf<IActionResult>(result); 
            }

            
            [Test]
            public void Test_DetailsReturns_ViewResult()
            {
                string assemblyName = "dotnetapp";
                Assembly assembly = Assembly.Load(assemblyName);
                string controllerTypeName = "dotnetapp.Controllers.BookController";
                Type controllerType = assembly.GetType(controllerTypeName);
                MethodInfo method = controllerType.GetMethod("Details");

                Assert.IsNotNull(method);
                var controllerInstance = Activator.CreateInstance(controllerType);
                int id = 0;
                var result = method.Invoke(controllerInstance, new object[] { id });

                Assert.IsNotNull(result);
                Assert.IsInstanceOf<ActionResult>(result);
            }

        [Test]
        public void Test_CreatePostMethodReturns_ViewResult()
        {
            string assemblyName = "dotnetapp";
            Assembly assembly = Assembly.Load(assemblyName);
            string controllerTypeName = "dotnetapp.Controllers.BookController";
            Type controllerType = assembly.GetType(controllerTypeName);
            MethodInfo method = controllerType.GetMethod("Create", new Type[] { typeof(Book) }); 

            Assert.IsNotNull(method);
            var controllerInstance = Activator.CreateInstance(controllerType);

            var book = new Book(); 

            var result = method.Invoke(controllerInstance, new object[] { book });

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ActionResult>(result);
        }



        [Test]
        public void TestIndexMethodExists()
        {
            string assemblyName = "dotnetapp";
            Assembly assembly = Assembly.Load(assemblyName);
            string controllerTypeName = "dotnetapp.Controllers.BookController";
            Type controllerType = assembly.GetType(controllerTypeName);
            MethodInfo method = controllerType.GetMethod("Index");
            Assert.IsNotNull(method);
        }


        [Test]
        public void TestCreateGetMethodExists()
        {
            string assemblyName = "dotnetapp";
            Assembly assembly = Assembly.Load(assemblyName);
            string controllerTypeName = "dotnetapp.Controllers.BookController";
            Type controllerType = assembly.GetType(controllerTypeName);
            MethodInfo method = controllerType.GetMethod("Create", new[] { typeof(Book) });
            Assert.IsNotNull(method);
        }

        [Test]
        public void TestCreatePostMethodExists()
        {

            string assemblyName = "dotnetapp";
            Assembly assembly = Assembly.Load(assemblyName);
            string controllerTypeName = "dotnetapp.Controllers.BookController";
            Type controllerType = assembly.GetType(controllerTypeName);
            MethodInfo method = controllerType.GetMethod("Create", new Type[] { typeof(Book) });
            Assert.IsNotNull(method);
        }

        [Test]
        public void TestBookClassExists()
        {  
             string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Book";
            Assembly assembly = Assembly.Load(assemblyName);
            Type bookType = assembly.GetType(typeName);
            Assert.IsNotNull(bookType);   
        }


        [Test]
        public void TestBookIDProperty()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Book";
            Assembly assembly = Assembly.Load(assemblyName);
            Type commuterType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = commuterType.GetProperty("BookID");
            Assert.IsNotNull(propertyInfo, "The property 'BookID' was not found on the Book class.");
            Type propertyType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(int), propertyType, "The data type of 'BookID' property is not as expected (Int).");
        }

        [Test]
        public void TestTitleProperty()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Book";
            Assembly assembly = Assembly.Load(assemblyName);
            Type commuterType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = commuterType.GetProperty("Title");
            Assert.IsNotNull(propertyInfo, "The property 'Title' was not found on the Book class.");
            Type propertyType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(string), propertyType, "The data type of 'Title' property is not as expected (string).");
        }

        [Test]
        public void TestPriceProperty()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Book";
            Assembly assembly = Assembly.Load(assemblyName);
            Type commuterType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = commuterType.GetProperty("Price");
            Assert.IsNotNull(propertyInfo, "The property 'Price' was not found on the Book class.");
            Type propertyType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(decimal), propertyType, "The data type of 'Price' property is not as expected (decimal).");
        }
        [Test]
        public void TestQuantityProperty()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Book";
            Assembly assembly = Assembly.Load(assemblyName);
            Type commuterType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = commuterType.GetProperty("Quantity");
            Assert.IsNotNull(propertyInfo, "The property 'Quantity' was not found on the Book class.");
            Type propertyType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(int), propertyType, "The data type of 'Quantity' property is not as expected (Int).");
        }

        [Test]
        public void Test_CreateViewFile_Exists()
        {
            string indexPath = Path.Combine(@"/home/coder/project/workspace/dotnetapp/Views/Book", "Create.cshtml");
            bool indexViewExists = File.Exists(indexPath);

            Assert.IsTrue(indexViewExists, "Create.cshtml view file does not exist.");
        }

        [Test]
        public void Test_IndexViewFile_Exists()
        {
            string indexPath = Path.Combine(@"/home/coder/project/workspace/dotnetapp/Views/Book", "Index.cshtml");
            bool indexViewExists = File.Exists(indexPath);

            Assert.IsTrue(indexViewExists, "Index.cshtml view file does not exist.");
        }

        
    [Test]
        public void Book_ClassExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Book";
            Assembly assembly = Assembly.Load(assemblyName);
            Type bookType = assembly.GetType(typeName);
            Assert.IsNotNull(bookType);
            var book = Activator.CreateInstance(bookType);
            Assert.IsNotNull(book);
        }

    [Test]
        public void BookController_ClassExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.BookController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type controllerType = assembly.GetType(typeName);
            Assert.IsNotNull(controllerType);
            var controller = Activator.CreateInstance(controllerType);
            Assert.IsNotNull(controller);
        }


        const puppeteer = require('puppeteer');
        (async () => {
            const browser = await puppeteer.launch({
            headless: false,
            args: ['--headless', '--disable-gpu', '--remote-debugging-port=9222', '--no-sandbox', '--disable-setuid-sandbox']
        });

        const page = await browser.newPage();
        try{
        await page.goto('http://localhost:8080/');
    }
}