using System.Numerics;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Microsoft.Data.SqlClient;
using System;
using dotnetapp.Models;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Newtonsoft.Json;

namespace TestProject
{
public class Tests
{
        private HttpClient _httpClient;
        private string _adminToken;

        [SetUp]
        public void Setup()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:8080"); 

        }

        [Test]
        public void Book_Models_ClassExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Book";
            Assembly assembly = Assembly.Load(assemblyName);
            Type BookType = assembly.GetType(typeName);
            Assert.IsNotNull(BookType);
        }

        [Test]
        public void Book_BookId_PropertyExists_ReturnExpectedDataTypes_int()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Book";
            Assembly assembly = Assembly.Load(assemblyName);
            Type BookType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = BookType.GetProperty("BookId");
            Assert.IsNotNull(propertyInfo, "Property BookId does not exist in Book class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(int), expectedType, "Property BookId in Book class is not of type int");
        }

        [Test]
        public void Book_BookName_PropertyExists_ReturnExpectedDataTypes_string()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Book";
            Assembly assembly = Assembly.Load(assemblyName);
            Type BookType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = BookType.GetProperty("BookName");
            Assert.IsNotNull(propertyInfo, "Property BookName does not exist in Book class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(string), expectedType, "Property BookName in Book class is not of type string");
        }

        [Test]
        public void Book_Category_PropertyExists_ReturnExpectedDataTypes_string()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Book";
            Assembly assembly = Assembly.Load(assemblyName);
            Type BookType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = BookType.GetProperty("Category");
            Assert.IsNotNull(propertyInfo, "Property Category does not exist in Book class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(string), expectedType, "Property Category in Book class is not of type string");
        }

         [Test]
        public void Book_Price_PropertyExists_ReturnExpectedDataTypes_decimal()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Book";
            Assembly assembly = Assembly.Load(assemblyName);
            Type BookType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = BookType.GetProperty("Price");
            Assert.IsNotNull(propertyInfo, "Property Price does not exist in Book class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(decimal), expectedType, "Property Price in Book class is not of type decimal");
        }

        [Test]
        public void Order_Model_ClassExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Order";
            Assembly assembly = Assembly.Load(assemblyName);
            Type OrderType = assembly.GetType(typeName);
            Assert.IsNotNull(OrderType);
        }

        [Test]
        public void Order_OrderId_PropertyExists_ReturnExpectedDataTypes_int()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Order";
            Assembly assembly = Assembly.Load(assemblyName);
            Type OrderType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = OrderType.GetProperty("OrderId");
            Assert.IsNotNull(propertyInfo, "Property OrderId does not exist in Order class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(int), expectedType, "Property OrderId in Post class is not of type int");
        }

        [Test]
        public void Order_CustomerName_PropertyExists_ReturnExpectedDataTypes_string()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Order";
            Assembly assembly = Assembly.Load(assemblyName);
            Type OrderType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = OrderType.GetProperty("CustomerName");
            Assert.IsNotNull(propertyInfo, "Property CustomerName does not exist in Order class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(string), expectedType, "Property CustomerName in Order class is not of type string");
        }

        [Test]
        public void Order_TotalAmount_PropertyExists_ReturnExpectedDataTypes_int()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Order";
            Assembly assembly = Assembly.Load(assemblyName);
            Type OrderType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = OrderType.GetProperty("TotalAmount");
            Assert.IsNotNull(propertyInfo, "Property TotalAmount does not exist in Order class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(int), expectedType, "Property TotalAmount in Post class is not of type int");
        }

        [Test]
        public void BookController_AddBook_MethodExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.BookController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type BookControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = BookControllerType.GetMethod("AddBook");
            Assert.IsNotNull(methodInfo, "Method AddBook does not exist in BookController class");
        }

        [Test]
        public void BookController_GetAllBooks_MethodExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.BookController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type BookControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = BookControllerType.GetMethod("GetAllBooks");
            Assert.IsNotNull(methodInfo, "Method GetAllBooks does not exist in BookController class");
        }

        [Test]
        public void BookController_DeleteBook_MethodExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.BookController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type BookControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = BookControllerType.GetMethod("DeleteBook");
            Assert.IsNotNull(methodInfo, "Method DeleteBook does not exist in BookController class");
        }

         [Test]
        public void OrderController_AddOrder_MethodExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.OrderController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type OrderControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = OrderControllerType.GetMethod("AddOrder");
            Assert.IsNotNull(methodInfo, "Method AddOrder does not exist in OrderController class");
        }

        [Test]
        public void OrderController_GetAllOrders_MethodExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.OrderController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type OrderControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = OrderControllerType.GetMethod("GetAllOrders");
            Assert.IsNotNull(methodInfo, "Method GetAllOrders does not exist in OrderController class");
        }

        [Test]
        public void OrderController_DeleteOrder_MethodExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.OrderController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type OrderControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = OrderControllerType.GetMethod("DeleteOrder");
            Assert.IsNotNull(methodInfo, "Method DeleteOrder does not exist in OrderController class");
        }

        [Test]
        public async Task Backend_TestAddBook()
        {
            // Create a unique title, category, and price for the book
            string uniqueTitle = Guid.NewGuid().ToString();
            string uniqueCategory = $"Category_{uniqueTitle}";
            decimal uniquePrice = new Random().Next(1, 100); // Assuming the price is a decimal

            // Create the book JSON request body
            string bookJson = $"{{\"BookName\":\"{uniqueTitle}\",\"Category\":\"{uniqueCategory}\",\"Price\":{uniquePrice}}}";

            // Send the POST request to add a book without authorization header
            HttpResponseMessage response = await _httpClient.PostAsync("/api/Book",
                new StringContent(bookJson, Encoding.UTF8, "application/json"));

            // Check if the request was successful
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [Test]
        public async Task Backend_TestGetAllBooks()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/api/Book");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            string responseBody = await response.Content.ReadAsStringAsync();
            var books = JsonConvert.DeserializeObject<List<Book>>(responseBody);
            Assert.IsNotNull(books);
        }

        [Test]
        public async Task Backend_TestDeleteBook()
        {
            // Generate unique identifiers
            string uniqueId = Guid.NewGuid().ToString();
            string uniqueTitle = $"BookTitle_{uniqueId}";
            string uniqueCategory = $"BookCategory_{uniqueId}";
            double uniquePrice = 29.99;

            // Create a book to delete
            var initialBookDetails = new
            {
                BookName = uniqueTitle,
                Category = uniqueCategory,
                Price = uniquePrice
            };

            string initialBookRequestBody = JsonConvert.SerializeObject(initialBookDetails);
            HttpResponseMessage addBookResponse = await _httpClient.PostAsync("/api/Book", new StringContent(initialBookRequestBody, Encoding.UTF8, "application/json"));
            Assert.AreEqual(HttpStatusCode.Created, addBookResponse.StatusCode);

            // Get the added book details
            string addBookResponseBody = await addBookResponse.Content.ReadAsStringAsync();
            dynamic addBookResponseMap = JsonConvert.DeserializeObject(addBookResponseBody);

            // Extract the bookId for deletion
            int? id = addBookResponseMap?.bookId;
            Console.WriteLine(bookId);

            if (bookId.HasValue)
            {
                // Delete the book
                HttpResponseMessage deleteBookResponse = await _httpClient.DeleteAsync($"/api/Book/{id}");

                // Assert that the book is deleted successfully
                Assert.AreEqual(HttpStatusCode.NoContent, deleteBookResponse.StatusCode);
            }
            else
            {
                // Log additional information for debugging
                string responseContent = await addBookResponse.Content.ReadAsStringAsync();
                Console.WriteLine($"Add Book Response Content: {responseContent}");

                Assert.Fail("Book ID is null or not found in the response.");
            }
        }



}
}