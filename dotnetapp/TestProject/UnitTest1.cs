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

        // Test to check whether Appointment Models Class exists
        [Test]
        public void Appointment_Models_ClassExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Appointment";
            Assembly assembly = Assembly.Load(assemblyName);
            Type AppointmentType = assembly.GetType(typeName);
            Assert.IsNotNull(AppointmentType);
        }

        // Test to Check Appointment Models Property Appointmentid Exists with correcct datatype int    
        [Test]
        public void Appointment_Appointmentid_PropertyExists_ReturnExpectedDataTypes_int()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Appointment";
            Assembly assembly = Assembly.Load(assemblyName);
            Type AppointmentType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = AppointmentType.GetProperty("Appointmentid");
            Assert.IsNotNull(propertyInfo, "Property Appointmentid does not exist in Appointment class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(int), expectedType, "Property Appointmentid in Appointment class is not of type int");
        }

        // Test to Check Appointment Models Property Patientname Exists with correcct datatype string    
        [Test]
        public void Appointment_Patientname_PropertyExists_ReturnExpectedDataTypes_string()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Appointment";
            Assembly assembly = Assembly.Load(assemblyName);
            Type AppointmentType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = AppointmentType.GetProperty("Patientname");
            Assert.IsNotNull(propertyInfo, "Property Patientname does not exist in Appointment class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(string), expectedType, "Property Patientname in Appointment class is not of type string");
        }

        // Test to Check Appointment Models Property Doctorname Exists with correcct datatype string    
        [Test]
        public void Appointment_Doctorname_PropertyExists_ReturnExpectedDataTypes_string()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Appointment";
            Assembly assembly = Assembly.Load(assemblyName);
            Type AppointmentType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = AppointmentType.GetProperty("Doctorname");
            Assert.IsNotNull(propertyInfo, "Property Doctorname does not exist in Appointment class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(string), expectedType, "Property Doctorname in Appointment class is not of type string");
        }

        // Test to Check Appointment Models Property StartTime Exists with correcct datatype DateTime    
        [Test]
        public void Appointment_StartTime_PropertyExists_ReturnExpectedDataTypes_DateTime()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Appointment";
            Assembly assembly = Assembly.Load(assemblyName);
            Type AppointmentType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = AppointmentType.GetProperty("StartTime");
            Assert.IsNotNull(propertyInfo, "Property StartTime does not exist in Appointment class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(DateTime), expectedType, "Property StartTime in Appointment class is not of type DateTime");
        }

        // Test to Check Appointment Models Property EndTime Exists with correcct datatype DateTime    
        [Test]
        public void Appointment_EndTime_PropertyExists_ReturnExpectedDataTypes_DateTime()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Appointment";
            Assembly assembly = Assembly.Load(assemblyName);
            Type AppointmentType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = AppointmentType.GetProperty("EndTime");
            Assert.IsNotNull(propertyInfo, "Property EndTime does not exist in Appointment class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(DateTime), expectedType, "Property EndTime in Appointment class is not of type DateTime");
        }

        // Test to Check Appointment Models Property Reason Exists with correcct datatype string    
        [Test]
        public void Appointment_Reason_PropertyExists_ReturnExpectedDataTypes_string()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Models.Appointment";
            Assembly assembly = Assembly.Load(assemblyName);
            Type AppointmentType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = AppointmentType.GetProperty("Reason");
            Assert.IsNotNull(propertyInfo, "Property Reason does not exist in Appointment class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(string), expectedType, "Property Reason in Appointment class is not of type string");
        }

        // Test to check whether AppointmentController Controllers Class exists
        [Test]
        public void AppointmentController_Controllers_ClassExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.AppointmentController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type AppointmentControllerType = assembly.GetType(typeName);
            Assert.IsNotNull(AppointmentControllerType);
        }

        // Test to Check AppointmentController Controllers Method Index Exists
        [Test]
        public void AppointmentController_Index_MethodExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.AppointmentController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type AppointmentControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = AppointmentControllerType.GetMethod("Index");
            Assert.IsNotNull(methodInfo, "Method Index does not exist in AppointmentController class");
        }

        // Test to Check AppointmentController Controllers Method Index Returns ActionResult
        [Test]
        public void AppointmentController_Index_MethodReturns_ActionResult()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.AppointmentController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type AppointmentControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = AppointmentControllerType.GetMethod("Index");
            Assert.AreEqual(typeof(ActionResult), methodInfo.ReturnType, "Method Index in AppointmentController class is not of type ActionResult");
        }

        // Test to Check AppointmentController Controllers Method Create Exists
        [Test]
        public void AppointmentController_Create_MethodExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.AppointmentController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type AppointmentControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = AppointmentControllerType.GetMethod("Create", Type.EmptyTypes);
            Assert.IsNotNull(methodInfo, "Method Create does not exist in AppointmentController class");
        }

        // Test to Check AppointmentController Controllers Method Create with no parameter Returns ActionResult
        [Test]
        public void AppointmentController_Create_Method_with_NoParams_Returns_ActionResult()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.AppointmentController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type AppointmentControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = AppointmentControllerType.GetMethod("Create", Type.EmptyTypes);
            Assert.AreEqual(typeof(ActionResult), methodInfo.ReturnType, "Method Create in AppointmentController class is not of type ActionResult");
        }

        // Test to Check AppointmentController Controllers Method Create with Appoinment parameter Returns ActionResult
        [Test]
        public void AppointmentController_Create_Method_with_Appoinment_Params_Returns_ActionResult()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.AppointmentController";
            string typeName1 = "dotnetapp.Models.Appointment";
            Assembly assembly = Assembly.Load(assemblyName);
            Type AppointmentControllerType = assembly.GetType(typeName);
            Type AppointmentModelType = assembly.GetType(typeName1);
            MethodInfo methodInfo = AppointmentControllerType.GetMethod("Create", new[] { AppointmentModelType });
            Assert.AreEqual(typeof(ActionResult), methodInfo.ReturnType, "Method Create in AppointmentController class is not of type ActionResult");
            object instanceOfController = Activator.CreateInstance(AppointmentControllerType);
            object instanceOfModel = Activator.CreateInstance(AppointmentModelType);
            object result = methodInfo.Invoke(instanceOfController, new object[] { instanceOfModel });
            Assert.IsNotNull(result);
        }


        // Test to Check AppointmentController Controllers Method Delete Exists
        [Test]
        public void AppointmentController_Delete_MethodExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.AppointmentController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type AppointmentControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = AppointmentControllerType.GetMethod("Delete");
            Assert.IsNotNull(methodInfo, "Method Delete does not exist in AppointmentController class");
        }

        // Test to Check AppointmentController Controllers Method Delete Returns ActionResult
        [Test]
        public void AppointmentController_Delete_MethodReturns_ActionResult()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.AppointmentController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type AppointmentControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = AppointmentControllerType.GetMethod("Delete");
            Assert.AreEqual(typeof(ActionResult), methodInfo.ReturnType, "Method Delete in AppointmentController class is not of type ActionResult");
        }

        // Test to Check AppointmentController Controllers Method Delete with parameter int Returns ActionResult
        [Test]
        public void AppointmentController_Delete_Method_Invokes_with_int_Param_Returns_ActionResult()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.AppointmentController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type AppointmentControllerType = assembly.GetType(typeName);
            object instance = Activator.CreateInstance(AppointmentControllerType);
            MethodInfo methodInfo = AppointmentControllerType.GetMethod("Delete", new Type[] { typeof(int) });
            object result = methodInfo.Invoke(instance, new object[] { 4562 });
            Console.WriteLine(result.GetType().Name);  
            Assert.IsNotNull(result, "Result should not be null");
        }

        [Test]
        public void ShouldUseADONET_Classes_SqlCommand()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.AppointmentController";
            Assembly assembly1 = Assembly.Load(assemblyName);
            Type CarserviceControllerType = assembly1.GetType(typeName);
            var assembly = Assembly.GetAssembly(CarserviceControllerType);
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
            string typeName = "dotnetapp.Controllers.AppointmentController";
            Assembly assembly1 = Assembly.Load(assemblyName);
            Type CarserviceControllerType = assembly1.GetType(typeName);
            var assembly = Assembly.GetAssembly(CarserviceControllerType);
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
    }
}


