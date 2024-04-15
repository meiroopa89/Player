using System.Numerics;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Microsoft.Data.SqlClient;
using System;
using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;


namespace TestProject
{

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
        public void Restaurant_Models_ClassExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Restaurant";
            Assembly assembly = Assembly.Load(assemblyName);
            Type RestaurantType = assembly.GetType(typeName);
            Assert.IsNotNull(RestaurantType);
        }

        // Test to Check Restaurant Models Property Id Exists with correcct datatype int    
        [Test]
        public void Restaurant_Id_PropertyExists_ReturnExpectedDataTypes_int()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Restaurant";
            Assembly assembly = Assembly.Load(assemblyName);
            Type RestaurantType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = RestaurantType.GetProperty("Id");
            Assert.IsNotNull(propertyInfo, "Property Id does not exist in Restaurant class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(int), expectedType, "Property Id in Restaurant class is not of type int");
        }

        [Test]
        public void Restaurant_Name_PropertyExists_ReturnExpectedDataTypes_string()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Restaurant";
            Assembly assembly = Assembly.Load(assemblyName);
            Type RestaurantType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = RestaurantType.GetProperty("Name");
            Assert.IsNotNull(propertyInfo, "Property Name does not exist in Restaurant class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(string), expectedType, "Property Name in Restaurant class is not of type string");
        }
        [Test]
        public void Restaurant_Description_PropertyExists_ReturnExpectedDataTypes_string()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Restaurant";
            Assembly assembly = Assembly.Load(assemblyName);
            Type RestaurantType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = RestaurantType.GetProperty("Description");
            Assert.IsNotNull(propertyInfo, "Property Name does not exist in Restaurant class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(string), expectedType, "Property Description in Restaurant class is not of type string");
        }

        [Test]
        public void Restaurant_Location_PropertyExists_ReturnExpectedDataTypes_string()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Restaurant";
            Assembly assembly = Assembly.Load(assemblyName);
            Type RestaurantType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = RestaurantType.GetProperty("Location");
            Assert.IsNotNull(propertyInfo, "Property Name does not exist in Restaurant class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(string), expectedType, "Property Location in Restaurant class is not of type string");
        }

        [Test]
        public void Restaurant_CuisineType_PropertyExists_ReturnExpectedDataTypes_string()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Restaurant";
            Assembly assembly = Assembly.Load(assemblyName);
            Type RestaurantType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = RestaurantType.GetProperty("CuisineType");
            Assert.IsNotNull(propertyInfo, "Property Name does not exist in Restaurant class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(string), expectedType, "Property CuisineType in Restaurant class is not of type string");
        }
  

        [Test]
        public void Restaurant_OpeningTime_PropertyExists_ReturnExpectedDataTypes_TimeSpan()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Restaurant";
            Assembly assembly = Assembly.Load(assemblyName);
            Type RestaurantType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = RestaurantType.GetProperty("OpeningTime");
            Assert.IsNotNull(propertyInfo, "Property OpeningTime does not exist in Restaurant class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(TimeSpan), expectedType, "Property OpeningTime in Restaurant class is not of type TimeSpan");
        }

        [Test]
        public void Restaurant_ClosingTime_PropertyExists_ReturnExpectedDataTypes_TimeSpan()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Restaurant";
            Assembly assembly = Assembly.Load(assemblyName);
            Type RestaurantType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = RestaurantType.GetProperty("ClosingTime");
            Assert.IsNotNull(propertyInfo, "Property ClosingTime does not exist in Restaurant class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(TimeSpan), expectedType, "Property ClosingTime in Restaurant class is not of type TimeSpan");
        }

        [Test]
        public void RestaurantController_Controllers_ClassExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.RestaurantController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type RestaurantControllerType = assembly.GetType(typeName);
            Assert.IsNotNull(RestaurantControllerType);
        }

        [Test]
        public void RestaurantController_Create_MethodExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.RestaurantController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type RestaurantControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = RestaurantControllerType.GetMethod("Create", Type.EmptyTypes);
            Assert.IsNotNull(methodInfo, "Method Create does not exist in RestaurantController class");
        }

        [Test]
        public void RestaurantController_Create_Method_with_NoParams_Returns_IActionResult()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.RestaurantController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type RestaurantControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = RestaurantControllerType.GetMethod("Create", Type.EmptyTypes);
            Assert.AreEqual(typeof(IActionResult), methodInfo.ReturnType, "Method Create in RestaurantController class is not of type IActionResult");
        }

        [Test]
        public void Create_in_RestaurantController_Add_new_Restaurant_to_DB()
        {
            // Arrange
            string assemblyName = "dotnetapp";
            Assembly assembly = Assembly.Load(assemblyName);
            string modelTypeName = "dotnetapp.Models.Restaurant";
            string controllerTypeName = "dotnetapp.Controllers.RestaurantController";
            Type controllerType = assembly.GetType(controllerTypeName);
            Type modelType = assembly.GetType(modelTypeName);

            // Prepare data for creating a new Restaurant
            var restaurantData = new Dictionary<string, object>
            {
                { "Name", "Sample Restaurant" },
                { "Location", "Sample Location" },
                { "Description", "Sample Description" },
                { "CuisineType", "Sample CuisineType" },
                { "OpeningTime", TimeSpan.FromHours(10) },
                { "ClosingTime", TimeSpan.FromHours(22) }
            };

            var restaurant = new Restaurant();
            foreach (var kvp in restaurantData)
            {
                var propertyInfo = modelType.GetProperty(kvp.Key);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(restaurant, kvp.Value);
                }
            }

            // Invoke the Create method in the RestaurantController
            MethodInfo method = controllerType.GetMethod("Create", new[] { modelType });
            if (method != null)
            {
                // Create DbContextOptions using DbContextOptionsBuilder
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(databaseName: "TestDatabase");
                var options = optionsBuilder.Options;

                var dbContextInstance = new ApplicationDbContext(options);
                var controller = Activator.CreateInstance(controllerType, dbContextInstance);
                var result = method.Invoke(controller, new object[] { restaurant });

                // Validate the result
                var savedRestaurant = dbContextInstance.Restaurants.FirstOrDefault(p => p.Name == "Sample Restaurant");
                Assert.IsNotNull(savedRestaurant);
                Assert.AreEqual("Sample Location", savedRestaurant.Location);
                Assert.AreEqual("Sample Description", savedRestaurant.Description);
                Assert.AreEqual("Sample CuisineType", savedRestaurant.CuisineType);
                Assert.AreEqual(TimeSpan.FromHours(10), savedRestaurant.OpeningTime);
                Assert.AreEqual(TimeSpan.FromHours(22), savedRestaurant.ClosingTime);

                // Optionally, clean up by deleting the added Restaurant from the database
                dbContextInstance.Restaurants.Remove(savedRestaurant);
                dbContextInstance.SaveChanges();
            }
            else
            {
                Assert.Fail("Create method not found in RestaurantController");
            }
        }


}
}