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
        [Test]
        public void Post_Model_ClassExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Model.Post";
            Assembly assembly = Assembly.Load(assemblyName);
            Type postType = assembly.GetType(typeName);
            Assert.IsNotNull(postType);
        }

}
}