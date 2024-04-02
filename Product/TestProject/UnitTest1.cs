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
}
}