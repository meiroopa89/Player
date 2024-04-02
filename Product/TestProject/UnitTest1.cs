using System.Numerics;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Microsoft.Data.SqlClient;
using System;

namespace TestProject
{

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
        public void Product_Models_ClassExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Product";
            Assembly assembly = Assembly.Load(assemblyName);
            Type ProductType = assembly.GetType(typeName);
            Assert.IsNotNull(ProductType);
        }

        // Test to Check Product Models Property Id Exists with correcct datatype int    
        [Test]
        public void Product_Id_PropertyExists_ReturnExpectedDataTypes_int()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Product";
            Assembly assembly = Assembly.Load(assemblyName);
            Type ProductType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = ProductType.GetProperty("Id");
            Assert.IsNotNull(propertyInfo, "Property Id does not exist in Product class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(int), expectedType, "Property Id in Product class is not of type int");
        }

        [Test]
        public void Product_Name_PropertyExists_ReturnExpectedDataTypes_string()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Product";
            Assembly assembly = Assembly.Load(assemblyName);
            Type ProductType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = ProductType.GetProperty("Name");
            Assert.IsNotNull(propertyInfo, "Property Name does not exist in Product class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(string), expectedType, "Property Name in Product class is not of type string");
        }
        [Test]
        public void Product_Description_PropertyExists_ReturnExpectedDataTypes_string()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Product";
            Assembly assembly = Assembly.Load(assemblyName);
            Type ProductType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = ProductType.GetProperty("Description");
            Assert.IsNotNull(propertyInfo, "Property Name does not exist in Product class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(string), expectedType, "Property Description in Product class is not of type string");
        }

        [Test]
        public void Product_Category_PropertyExists_ReturnExpectedDataTypes_string()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Product";
            Assembly assembly = Assembly.Load(assemblyName);
            Type ProductType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = ProductType.GetProperty("Category");
            Assert.IsNotNull(propertyInfo, "Property Name does not exist in Product class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(string), expectedType, "Property Category in Product class is not of type string");
        }

        public void Product_Price_PropertyExists_ReturnExpectedDataTypes_decimal()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Product";
            Assembly assembly = Assembly.Load(assemblyName);
            Type ProductType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = ProductType.GetProperty("Price");
            Assert.IsNotNull(propertyInfo, "Property Name does not exist in Product class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(decimal), expectedType, "Property Price in Product class is not of type decimal");
        }

        [Test]
        public void Product_StockQuantity_PropertyExists_ReturnExpectedDataTypes_int()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Product";
            Assembly assembly = Assembly.Load(assemblyName);
            Type ProductType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = ProductType.GetProperty("StockQuantity");
            Assert.IsNotNull(propertyInfo, "Property StockQuantity does not exist in Product class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(int), expectedType, "Property StockQuantity in Product class is not of type int");
        }

        [Test]
        public void Product_ExpiryDate_PropertyExists_ReturnExpectedDataTypes_DateTime()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Product";
            Assembly assembly = Assembly.Load(assemblyName);
            Type ProductType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = ProductType.GetProperty("ExpiryDate");
            Assert.IsNotNull(propertyInfo, "Property ExpiryDate does not exist in Product class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(DateTime), expectedType, "Property ExpiryDate in Product class is not of type DateTime");
        }

        [Test]
        public void ProductController_Controllers_ClassExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.ProductController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type ProductControllerType = assembly.GetType(typeName);
            Assert.IsNotNull(ProductControllerType);
        }

        [Test]
        public void ProductController_View_MethodReturns_IActionResult()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.ProductController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type ProductControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = ProductControllerType.GetMethod("ViewProducts");
            Assert.AreEqual(typeof(IActionResult), methodInfo.ReturnType, "Method View in ProductController class is not of type ActionResult");
        }

        [Test]
        public void ProductController_Create_Method_with_NoParams_Returns_IActionResult()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.ProductController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type ProductControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = ProductControllerType.GetMethod("Create", Type.EmptyTypes);
            Assert.AreEqual(typeof(IActionResult), methodInfo.ReturnType, "Method Create in ProductController class is not of type ActionResult");
        }

       

}
}