using System.Numerics;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Microsoft.Data.SqlClient;
using System;



namespace TestProject;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    // [Test]
    // public void Test1()
    // {
    //     Assert.Pass();
    // }

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

        VerificationDetails
}