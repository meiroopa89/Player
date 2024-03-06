using System.Numerics;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Microsoft.Data.SqlClient;
using System;
using Moq;
using dotnetapp.Model;
using dotnetapp.Controllers;

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

        [Test]
        public void Post_Id_PropertyExists_ReturnExpectedDataTypes_int()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Model.Post";
            Assembly assembly = Assembly.Load(assemblyName);
            Type PostType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = PostType.GetProperty("Id");
            Assert.IsNotNull(propertyInfo, "Property Id does not exist in Post class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(int), expectedType, "Property Id in Post class is not of type int");
        }

        [Test]
        public void Post_Title_PropertyExists_ReturnExpectedDataTypes_string()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Model.Post";
            Assembly assembly = Assembly.Load(assemblyName);
            Type PostType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = PostType.GetProperty("Title");
            Assert.IsNotNull(propertyInfo, "Property Title does not exist in Post class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(string), expectedType, "Property Title in Post class is not of type string");
        }

        [Test]
        public void Post_Content_PropertyExists_ReturnExpectedDataTypes_string()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Model.Post";
            Assembly assembly = Assembly.Load(assemblyName);
            Type PostType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = PostType.GetProperty("Content");
            Assert.IsNotNull(propertyInfo, "Property Content does not exist in Post class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(string), expectedType, "Property Content in Post class is not of type string");
        }

        [Test]
        public void Comment_Model_ClassExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Model.Comment";
            Assembly assembly = Assembly.Load(assemblyName);
            Type CommentType = assembly.GetType(typeName);
            Assert.IsNotNull(CommentType);
        }

        [Test]
        public void Comment_Id_PropertyExists_ReturnExpectedDataTypes_int()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Model.Comment";
            Assembly assembly = Assembly.Load(assemblyName);
            Type CommentType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = CommentType.GetProperty("Id");
            Assert.IsNotNull(propertyInfo, "Property Id does not exist in Comment class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(int), expectedType, "Property Id in Post class is not of type int");
        }

        [Test]
        public void Comment_Text_PropertyExists_ReturnExpectedDataTypes_string()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Model.Comment";
            Assembly assembly = Assembly.Load(assemblyName);
            Type CommentType = assembly.GetType(typeName);
            PropertyInfo propertyInfo = CommentType.GetProperty("Text");
            Assert.IsNotNull(propertyInfo, "Property Text does not exist in Comment class");
            Type expectedType = propertyInfo.PropertyType;
            Assert.AreEqual(typeof(string), expectedType, "Property Text in Comment class is not of type string");
        }

        [Test]
        public void PostController_Controllers_ClassExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.PostController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type PostControllerType = assembly.GetType(typeName);
            Assert.IsNotNull(PostControllerType);
        }

        [Test]
        public void CommentController_Controllers_ClassExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.CommentController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type CommentControllerType = assembly.GetType(typeName);
            Assert.IsNotNull(CommentControllerType);
        }

        [Test]
        public void PostController_AddPost_MethodExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.PostController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type postControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = postControllerType.GetMethod("AddPost");
            Assert.IsNotNull(methodInfo, "Method AddPost does not exist in PostController class");
        }

        // [Test]
        // public void PostController_AddPost_ReturnsOkResult()
        // {
        //     // Arrange
        //     var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        //         .UseInMemoryDatabase(databaseName: "BlogDB")
        //         .Options;

        //     using (var dbContext = new ApplicationDbContext(options))
        //     {
        //         var postController = new PostController(new PostRepository(dbContext));

        //         var validPost = new Post
        //         {
        //             Id = 1,
        //             Title = "Sample Title",
        //             Content = "Sample Content",
        //             Comments = new List<Comment>()
        //         };

        //         // Act
        //         var result = postController.AddPost(validPost);

        //         // Assert
        //         Assert.IsInstanceOf<OkObjectResult>(result);
        //     }
        // }

        [Test]
        public void PostController_GetAllPosts_MethodExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.PostController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type postControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = postControllerType.GetMethod("GetAllPosts");
            Assert.IsNotNull(methodInfo, "Method GetAllPosts does not exist in PostController class");
        }

        [Test]
        public void PostController_DeletePost_MethodExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.PostController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type PostControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = PostControllerType.GetMethod("DeletePost");
            Assert.IsNotNull(methodInfo, "Method DeletePost does not exist in PostController class");
        }
  
        [Test]
        public void PostController_DeletePost_MethodReturns_IActionResult()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.PostController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type PostControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = PostControllerType.GetMethod("DeletePost");
            Assert.AreEqual(typeof(IActionResult), methodInfo.ReturnType, "Method DeletePost in PostController class is not of type IActionResult");
        }

        [Test]
        public void CommentController_AddComment_MethodExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.CommentController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type CommentControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = CommentControllerType.GetMethod("AddComment");
            Assert.IsNotNull(methodInfo, "Method AddComment does not exist in CommentController class");
        }

        [Test]
        public void CommentController_GetAllComments_MethodExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.CommentController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type CommentControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = CommentControllerType.GetMethod("GetAllComments");
            Assert.IsNotNull(methodInfo, "Method GetAllComments does not exist in CommentController class");
        }


        [Test]
        public void CommentController_DeleteComment_MethodExists()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.CommentController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type CommentControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = CommentControllerType.GetMethod("DeleteComment");
            Assert.IsNotNull(methodInfo, "Method DeleteComment does not exist in CommentController class");
        }
  
        [Test]
        public void CommentController_DeleteComment_MethodReturns_IActionResult()
        {
            string assemblyName = "dotnetapp";
            string typeName = "dotnetapp.Controllers.CommentController";
            Assembly assembly = Assembly.Load(assemblyName);
            Type CommentControllerType = assembly.GetType(typeName);
            MethodInfo methodInfo = CommentControllerType.GetMethod("DeleteComment");
            Assert.AreEqual(typeof(IActionResult), methodInfo.ReturnType, "Method DeleteComment in CommentController class is not of type IActionResult");
        }

}
}