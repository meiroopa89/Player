using System.Numerics;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Microsoft.Data.SqlClient;
using System;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;


namespace TestProject
{
public class Tests
{

    private ApplicationDbContext _context;
    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Verify")
                .Options;
            _context = new ApplicationDbContext(options);
            _context.Database.EnsureCreated();
    }

        [Test]
        public void Candidate_Models_ClassExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Candidate";
            Assembly assembly = Assembly.Load(assemblyName);
            Type CandidateType = assembly.GetType(typeName);
            Assert.IsNotNull(CandidateType);
        }

        [Test]
        public void VerificationTask_Models_ClassExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.VerificationTask";
            Assembly assembly = Assembly.Load(assemblyName);
            Type VerificationTaskType = assembly.GetType(typeName);
            Assert.IsNotNull(VerificationTaskType);
        }

        [Test]
        public void Candidate_CandidateID_PropertyExists_ReturnExpectedDataTypes_int()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Candidate";
            Assembly assembly = Assembly.Load(assemblyName);
            Type CandidateType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = CandidateType.GetProperty("CandidateID");
            Assert.IsNotNull(propertyInfo, "Property CandidateID does not exist in Candidate class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(int), expectedType, "Property CandidateID in Candidate class is not of type int");
        }

        [Test]
        public void Candidate_CandidateName_PropertyExists_ReturnExpectedDataTypes_string()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Candidate";
            Assembly assembly = Assembly.Load(assemblyName);
            Type CandidateType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = CandidateType.GetProperty("CandidateName");
            Assert.IsNotNull(propertyInfo, "Property CandidateName does not exist in Candidate class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(string), expectedType, "Property CandidateName in Candidate class is not of type string");
        }

        [Test]
        public void VerificationTask_TaskID_PropertyExists_ReturnExpectedDataTypes_int()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.VerificationTask";
            Assembly assembly = Assembly.Load(assemblyName);
            Type VerificationTaskType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = VerificationTaskType.GetProperty("TaskID");
            Assert.IsNotNull(propertyInfo, "Property TaskID does not exist in VerificationTask class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(int), expectedType, "Property TaskID in VerificationTask class is not of type int");
        }

        
        [Test]
        public void VerificationTask_VerificationDetails_PropertyExists_ReturnExpectedDataTypes_string()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.VerificationTask";
            Assembly assembly = Assembly.Load(assemblyName);
            Type VerificationTaskType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = VerificationTaskType.GetProperty("VerificationDetails");
            Assert.IsNotNull(propertyInfo, "Property VerificationDetails does not exist in VerificationTask class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(string), expectedType, "Property VerificationDetails in VerificationTask class is not of type string");
        }

        [Test]
        public void VerificationTask_Status_PropertyExists_ReturnExpectedDataTypes_string()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.VerificationTask";
            Assembly assembly = Assembly.Load(assemblyName);
            Type VerificationTaskType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = VerificationTaskType.GetProperty("Status");
            Assert.IsNotNull(propertyInfo, "Property Status does not exist in VerificationTask class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(string), expectedType, "Property Status in VerificationTask class is not of type string");
        }

        [Test]
        public void CandidateController_Controllers_ClassExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.CandidateController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type CandidateControllerType = assembly.GetType(typeName);
            Assert.IsNotNull(CandidateControllerType);
        }

        [Test]
        public void VerificationController_Controllers_ClassExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.VerificationController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type VerificationControllerType = assembly.GetType(typeName);
            Assert.IsNotNull(VerificationControllerType);
        }


        [Test]
        public void VerificationController_Index_MethodExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.VerificationController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type VerificationControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = VerificationControllerType.GetMethod("Index");
            Assert.IsNotNull(methodInfo, "Method Index does not exist in VerificationController class");
        }

        [Test]
        public void VerificationController_Delete_MethodExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.VerificationController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type VerificationControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = VerificationControllerType.GetMethod("Delete");
            Assert.IsNotNull(methodInfo, "Method Delete does not exist in VerificationController class");
        }

        // [Test]
        // public void VerificationController_Edit_MethodExists()
        // {
        //     string assemblyName = "dotnetapp"; 
        //     string typeName = "dotnetapp.Controllers.VerificationController";
        //     Assembly assembly = Assembly.Load(assemblyName);
        //     Type verificationControllerType = assembly.GetType(typeName);
        //     MethodInfo editMethod = verificationControllerType.GetMethod("Edit");
        //     Assert.NotNull(editMethod, "Method Edit does not exist in VerificationController class");
        // }

        [Test]
        public void VerificationController_Task_MethodExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.VerificationController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type VerificationControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = VerificationControllerType.GetMethod("Task");
            Assert.IsNotNull(methodInfo, "Method Task does not exist in VerificationController class");
        }

        [Test]
        public void CandidateController_Create_MethodExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.CandidateController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type CandidateControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = CandidateControllerType.GetMethod("Create", Type.EmptyTypes);
            Assert.IsNotNull(methodInfo, "Method Create does not exist in CandidateController class");
        }

        [Test]
        public void VerificationController_Create_MethodExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.VerificationController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type VerificationControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = VerificationControllerType.GetMethod("Create", Type.EmptyTypes);
            Assert.IsNotNull(methodInfo, "Method Create does not exist in VerificationController class");
        }

        [Test]
        public void ApplicationDbContextContainsDbSetCandidateProperty()
        {

            var propertyInfo = _context.GetType().GetProperty("Candidates");

            Assert.IsNotNull(propertyInfo);
            Assert.AreEqual(typeof(DbSet<Candidate>), propertyInfo.PropertyType);
        }

        [Test]
        public void ApplicationDbContextContainsDbSetVerificationTaskProperty()
        {

            var propertyInfo = _context.GetType().GetProperty("VerificationTasks");

            Assert.IsNotNull(propertyInfo);
            Assert.AreEqual(typeof(DbSet<VerificationTask>), propertyInfo.PropertyType);
        }

        [Test]
        public void VerificationController_CreateGetMethodExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.VerificationController";
 
            Assembly assembly = Assembly.Load(assemblyName);
            Type controllerType = assembly.GetType(typeName);
 
            MethodInfo createGetMethod = controllerType.GetMethod("Create", new Type[] { });
 
            Assert.IsNotNull(createGetMethod);
            Assert.IsTrue(typeof(IActionResult).IsAssignableFrom(createGetMethod.ReturnType));
        }

        [Test]
        public void VerificationController_CreatePostMethodExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.VerificationController";
 
            Assembly assembly = Assembly.Load(assemblyName);
            Type controllerType = assembly.GetType(typeName);
 
            MethodInfo createPostMethod = controllerType.GetMethod("Create", new Type[] { });
 
            Assert.IsNotNull(createPostMethod);
            Assert.IsTrue(typeof(IActionResult).IsAssignableFrom(createPostMethod.ReturnType));
        }

        [Test]
        public void VerificationController_IndexPostMethodExists()
        {
            // Arrange
            string assemblyName = "dotnetapp"; 
            Assembly assembly = Assembly.Load(assemblyName);
            Assert.IsNotNull(assembly, "Assembly should not be null");

            string controllerName = "VerificationController"; 

            Type controllerType = assembly.GetType($"dotnetapp.Controllers.{controllerName}");
            Assert.IsNotNull(controllerType, "Controller type should not be null");

            // Act
            MethodInfo indexPostMethod = controllerType.GetMethod("Index", new Type[] { typeof(int?) });

            // Assert
            Assert.IsNotNull(indexPostMethod, "Index method should exist");
            Assert.IsTrue(typeof(IActionResult).IsAssignableFrom(indexPostMethod.ReturnType), "Index method should return IActionResult");
        }

        [Test]
        public void CandidateController_CreateGetMethodExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.CandidateController";
 
            Assembly assembly = Assembly.Load(assemblyName);
            Type controllerType = assembly.GetType(typeName);
 
            MethodInfo createGetMethod = controllerType.GetMethod("Create", new Type[] { });
 
            Assert.IsNotNull(createGetMethod);
            Assert.IsTrue(typeof(IActionResult).IsAssignableFrom(createGetMethod.ReturnType));
        }

        [Test]
        public void CandidateController_CreatePostMethodExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.CandidateController";

            Assembly assembly = Assembly.Load(assemblyName);
            Type controllerType = assembly.GetType(typeName);

            MethodInfo createPostMethod = controllerType.GetMethod("Create", Type.EmptyTypes);

            Assert.IsNotNull(createPostMethod);
            Assert.IsTrue(typeof(IActionResult).IsAssignableFrom(createPostMethod.ReturnType));
        }

        [Test]
        public void VerificationController_DeleteConfirmedMethodExists()
        {
            // Arrange
            string assemblyName = "dotnetapp"; // Replace with your assembly name
            Assembly assembly = Assembly.Load(assemblyName);
            Assert.IsNotNull(assembly, "Assembly should not be null");

            string controllerName = "VerificationController"; // Replace with your controller name

            Type controllerType = assembly.GetType($"dotnetapp.Controllers.{controllerName}");
            Assert.IsNotNull(controllerType, "Controller type should not be null");

            // Act
            MethodInfo deleteConfirmedMethod = controllerType.GetMethod("DeleteConfirmed", new Type[] { typeof(int) });

            // Assert
            Assert.IsNotNull(deleteConfirmedMethod, "DeleteConfirmed method should exist");
            Assert.IsTrue(typeof(IActionResult).IsAssignableFrom(deleteConfirmedMethod.ReturnType), "DeleteConfirmed method should return IActionResult");
        }

        [Test]
        public void VerificationController_TaskMethodExists()
        {
            // Arrange
            string assemblyName = "dotnetapp"; 
            Assembly assembly = Assembly.Load(assemblyName);
            Assert.IsNotNull(assembly, "Assembly should not be null");

            string controllerName = "VerificationController"; 

            Type controllerType = assembly.GetType($"dotnetapp.Controllers.{controllerName}");
            Assert.IsNotNull(controllerType, "Controller type should not be null");

            // Act
            MethodInfo taskMethod = controllerType.GetMethod("Task", new Type[] { typeof(int) });

            // Assert
            Assert.IsNotNull(taskMethod, "Task method should exist");
            Assert.AreEqual(typeof(IActionResult), taskMethod.ReturnType, "Task method should return IActionResult");

            ParameterInfo[] parameters = taskMethod.GetParameters();
            Assert.AreEqual(1, parameters.Length, "Task method should have one parameter");
            Assert.AreEqual(typeof(int), parameters[0].ParameterType, "Task method's parameter should be of type int");
        }

        [Test]
        public void VerificationController_EditPostMethodExists()
        {
            // Arrange
            string assemblyName = "dotnetapp"; // Replace with your assembly name
            Assembly assembly = Assembly.Load(assemblyName);
            Assert.IsNotNull(assembly, "Assembly should not be null");

            string controllerName = "VerificationController"; // Replace with your controller name

            Type controllerType = assembly.GetType($"dotnetapp.Controllers.{controllerName}");
            Assert.IsNotNull(controllerType, "Controller type should not be null");

            // Act
            MethodInfo editPostMethod = controllerType.GetMethod("Edit", new Type[] { typeof(int), typeof(VerificationTask) });

            // Assert
            Assert.IsNotNull(editPostMethod, "Edit method should exist");
            Assert.IsTrue(typeof(IActionResult).IsAssignableFrom(editPostMethod.ReturnType), "Edit method should return IActionResult");

            ParameterInfo[] parameters = editPostMethod.GetParameters();
            Assert.AreEqual(2, parameters.Length, "Edit method should have two parameters");

            Assert.AreEqual(typeof(int), parameters[0].ParameterType, "First parameter of Edit method should be of type int");
            Assert.AreEqual(typeof(VerificationTask), parameters[1].ParameterType, "Second parameter of Edit method should be of type VerificationTask");
        }

        [Test]
        public void VerificationController_DeleteGetMethodExists()
        {
            // Arrange
            string assemblyName = "dotnetapp"; // Replace with your assembly name
            Assembly assembly = Assembly.Load(assemblyName);
            Assert.IsNotNull(assembly, "Assembly should not be null");

            string controllerName = "VerificationController"; // Replace with your controller name

            Type controllerType = assembly.GetType($"dotnetapp.Controllers.{controllerName}");
            Assert.IsNotNull(controllerType, "Controller type should not be null");

            // Act
            MethodInfo deleteGetMethod = controllerType.GetMethod("Delete", new Type[] { typeof(int) });

            // Assert
            Assert.IsNotNull(deleteGetMethod, "Delete method should exist");
            Assert.IsTrue(typeof(IActionResult).IsAssignableFrom(deleteGetMethod.ReturnType), "Delete method should return IActionResult");

            ParameterInfo[] parameters = deleteGetMethod.GetParameters();
            Assert.AreEqual(1, parameters.Length, "Delete method should have one parameter");

            Assert.AreEqual(typeof(int), parameters[0].ParameterType, "Parameter of Delete method should be of type int");
        }

    }

}
