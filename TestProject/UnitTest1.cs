using System.Numerics;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Microsoft.Data.SqlClient;
using System;
using Microsoft.Data; 

namespace TestProject
{
    public class TestProject
    {

        // Test to check whether Appointment Models Class exists
        [Test]
        public void GymMembership_Models_ClassExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.GymMembership";
            Assembly assembly = Assembly.Load(assemblyName);
            Type GymMembershipType = assembly.GetType(typeName);
            Assert.IsNotNull(GymMembershipType);
        }

        // Test to Check Appointment Models Property Appointmentid Exists with correcct datatype int    
        [Test]
        public void GymMembership_id_PropertyExists_ReturnExpectedDataTypes_int()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.GymMembership";
            Assembly assembly = Assembly.Load(assemblyName);
            Type GymMembershipType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = GymMembershipType.GetProperty("id");
            Assert.IsNotNull(propertyInfo, "Property id does not exist in GymMembership class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(int), expectedType, "Property id in GymMembership class is not of type int");
        }

        // Test to Check GymMembership Models Property Patientname Exists with correcct datatype string    
        [Test]
        public void GymMembership_Name_PropertyExists_ReturnExpectedDataTypes_string()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.GymMembership";
            Assembly assembly = Assembly.Load(assemblyName);
            Type GymMembershipType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = GymMembershipType.GetProperty("Name");
            Assert.IsNotNull(propertyInfo, "Property Name does not exist in GymMembership class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(string), expectedType, "Property Name in GymMembership class is not of type string");
        }

       
        // Test to Check GymMembership Models Property JoiningDate Exists with correcct datatype DateTime    
        [Test]
        public void GymMembership_JoiningDate_PropertyExists_ReturnExpectedDataTypes_DateTime()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.GymMembership";
            Assembly assembly = Assembly.Load(assemblyName);
            Type GymMembershipType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = GymMembershipType.GetProperty("JoiningDate");
            Assert.IsNotNull(propertyInfo, "Property JoiningDate does not exist in GymMembership class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(DateTime), expectedType, "Property JoiningDate in GymMembership class is not of type DateTime");
        }

        // Test to Check GymMembership Models Property ExpiryDate Exists with correcct datatype DateTime    
        [Test]
        public void GymMembership_ExpiryDate_PropertyExists_ReturnExpectedDataTypes_DateTime()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.GymMembership";
            Assembly assembly = Assembly.Load(assemblyName);
            Type GymMembershipType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = GymMembershipType.GetProperty("ExpiryDate");
            Assert.IsNotNull(propertyInfo, "Property ExpiryDate does not exist in GymMembership class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(DateTime), expectedType, "Property ExpiryDate in GymMembership class is not of type DateTime");
        }

        // Test to Check GymMembership Models Property Reason Exists with correcct datatype string    
        [Test]
        public void GymMembership_MembershipType_PropertyExists_ReturnExpectedDataTypes_string()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.GymMembership";
            Assembly assembly = Assembly.Load(assemblyName);
            Type GymMembershipType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = GymMembershipType.GetProperty("MembershipType");
            Assert.IsNotNull(propertyInfo, "Property MembershipType does not exist in GymMembership class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(string), expectedType, "Property MembershipType in GymMembership class is not of type string");
        }

        // Test to check whether GymController Controllers Class exists
        [Test]
        public void GymController_Controllers_ClassExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.GymController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type GymControllerType = assembly.GetType(typeName);
            Assert.IsNotNull(GymControllerType);
        }

        // Test to Check GymController Controllers Method Index Exists
        [Test]
        public void GymController_Index_MethodExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.GymController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type GymControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = GymControllerType.GetMethod("Index");
            Assert.IsNotNull(methodInfo, "Method Index does not exist in GymController class");
        }

        // Test to Check GymController Controllers Method Index Returns ActionResult
        [Test]
        public void GymController_Index_MethodReturns_ActionResult()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.GymController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type GymControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = GymControllerType.GetMethod("Index");
            Assert.AreEqual(typeof(ActionResult), methodInfo.ReturnType, "Method Index in GymController class is not of type ActionResult");
        }

        // Test to Check GymController Controllers Method Create Exists
        [Test]
        public void GymController_Create_MethodExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.GymController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type GymController = assembly.GetType(typeName);
            MethodInfo methodInfo = GymController.GetMethod("Create", Type.EmptyTypes);
            Assert.IsNotNull(methodInfo, "Method Create does not exist in GymController class");
        }

        // Test to Check GymController Controllers Method Create with no parameter Returns ActionResult
        [Test]
        public void GymController_Create_Method_with_NoParams_Returns_ActionResult()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.GymController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type GymControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = GymControllerType.GetMethod("Create", Type.EmptyTypes);
            Assert.AreEqual(typeof(ActionResult), methodInfo.ReturnType, "Method Create in GymController class is not of type ActionResult");
        }

        // Test to Check GymController Controllers Method Create with GymMembership parameter Returns ActionResult
        [Test]
        public void GymController_Create_Method_with_GymMembership_Params_Returns_ActionResult()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.GymController";
            string typeName1 = "dotnetapp.Models.GymMembership";
            Assembly assembly = Assembly.Load(assemblyName);
            Type GymControllerType = assembly.GetType(typeName);
            Type GymMembershipModelType = assembly.GetType(typeName1);
            MethodInfo methodInfo = GymControllerType.GetMethod("Create", new[] { GymMembershipModelType });
            Assert.AreEqual(typeof(ActionResult), methodInfo.ReturnType, "Method Create in GymController class is not of type ActionResult");
            object instanceOfController = Activator.CreateInstance(GymControllerType);
            object instanceOfModel = Activator.CreateInstance(GymMembershipModelType);
            object result = methodInfo.Invoke(instanceOfController, new object[] { instanceOfModel });
            Assert.IsNotNull(result);
        }


        // Test to Check AppointmentController Controllers Method Edit Exists
        // [Test]
        // public void GymController_Edit_MethodExists()
        // {
        //     string assemblyName = "dotnetapp";
        //     string typeName = "dotnetapp.Controllers.GymController";
        //     Assembly assembly = Assembly.Load(assemblyName);
        //     Type GymControllerType = assembly.GetType(typeName);
        //     MethodInfo methodInfo = GymControllerType.GetMethod("Edit");
        //     Assert.IsNotNull(methodInfo, "Method Edit does not exist in GymController class");
        // }

        // Test to Check GymController Controllers Method Edit Returns ActionResult
        // [Test]
        // public void GymController_Edit_MethodReturns_ActionResult()
        // {
        //     string assemblyName = "dotnetapp";
        //     string typeName = "dotnetapp.Controllers.GymController";
        //     Assembly assembly = Assembly.Load(assemblyName);
        //     Type GymControllerType = assembly.GetType(typeName);
        //     MethodInfo methodInfo = GymControllerType.GetMethod("Edit");
        //     Assert.AreEqual(typeof(ActionResult), methodInfo.ReturnType, "Method Edit in GymController class is not of type ActionResult");
        // }

        // Test to Check AppointmentController Controllers Method Delete with parameter int Returns ActionResult
        // [Test]
        // public void AppointmentController_Delete_Method_Invokes_with_int_Param_Returns_ActionResult()
        // {
        //     string assemblyName = "dotnetapp";
        //     string typeName = "dotnetapp.Controllers.AppointmentController";
        //     Assembly assembly = Assembly.Load(assemblyName);
        //     Type AppointmentControllerType = assembly.GetType(typeName);
        //     object instance = Activator.CreateInstance(AppointmentControllerType);
        //     MethodInfo methodInfo = AppointmentControllerType.GetMethod("Delete", new Type[] { typeof(int) });
        //     object result = methodInfo.Invoke(instance, new object[] { 4562 });
        //     Console.WriteLine(result.GetType().Name);  
        //     Assert.IsNotNull(result, "Result should not be null");
        // }

        [Test]
        public void ShouldUseADONET_Classes_SqlCommand()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.GymController";
            Assembly assembly1 = Assembly.Load(assemblyName);
            Type GymControllerType = assembly1.GetType(typeName);
            var assembly = Assembly.GetAssembly(GymControllerType);
            var types = assembly.GetTypes();

            // Act
            var containsSqlCommand = types.Any(type =>
                type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                    .SelectMany(method => method.GetMethodBody()?.LocalVariables.Cast<LocalVariableInfo>() ?? Enumerable.Empty<LocalVariableInfo>())
                    .Any(variable => variable.LocalType == typeof(SqlCommand))
            );

            // Assert
            Assert.IsTrue(containsSqlCommand, "SqlCommand is not used in the application.");
        }

        [Test]
        public void ShouldUseADONET_Classes_SqlConnection()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.GymController";
            Assembly assembly1 = Assembly.Load(assemblyName);
            Type GymControllerType = assembly1.GetType(typeName);
            var assembly = Assembly.GetAssembly(GymControllerType);
            var types = assembly.GetTypes();

            // Act
            var containsSqlConnection = types.Any(type =>
                type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                    .SelectMany(method => method.GetMethodBody()?.LocalVariables.Cast<LocalVariableInfo>() ?? Enumerable.Empty<LocalVariableInfo>())
                    .Any(variable => variable.LocalType == typeof(SqlConnection))
            );

            // Assert
            Assert.IsTrue(containsSqlConnection, "SqlConnection is not used in the application.");
        }

        [Test]
        public void CreateCshtml_ViewFileExists()
        {
            // Replace the path below with the actual path to your Views folder
            string viewsFolderPath = "/home/coder/project/workspace/dotnetapp/Views";

            string filePath = Path.Combine(viewsFolderPath, "Gym", "Create.cshtml");

            bool fileExists = File.Exists(filePath);

            Assert.IsTrue(fileExists, "Create.cshtml file does not exist in the Views/Gym folder.");
        }

         [Test]
        public void IndexCshtml_ViewFileExists()
        {
            // Replace the path below with the actual path to your Views folder
            string viewsFolderPath = "/home/coder/project/workspace/dotnetapp/Views";

            string filePath = Path.Combine(viewsFolderPath, "Gym", "Index.cshtml");

            bool fileExists = File.Exists(filePath);

            Assert.IsTrue(fileExists, "Index.cshtml file does not exist in the Views/Gym folder.");
        }

    }
}


