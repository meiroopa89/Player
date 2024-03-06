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
}
}