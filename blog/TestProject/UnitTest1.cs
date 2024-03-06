using System.Numerics;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Microsoft.Data.SqlClient;
using System;
using dotnetapp.Model;
using System.Net.Http;
using System;
using System.Net;
using System.Net.Http;
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
  
        // [Test]
        // public void CommentController_DeleteComment_MethodReturns_IActionResult()
        // {
        //     string assemblyName = "dotnetapp";
        //     string typeName = "dotnetapp.Controllers.CommentController";
        //     Assembly assembly = Assembly.Load(assemblyName);
        //     Type CommentControllerType = assembly.GetType(typeName);
        //     MethodInfo methodInfo = CommentControllerType.GetMethod("DeleteComment");
        //     Assert.AreEqual(typeof(IActionResult), methodInfo.ReturnType, "Method DeleteComment in CommentController class is not of type IActionResult");
        // }

        [Test]
        public async Task Backend_TestAddPost()
        {
            // Create a unique title and content for the post
            string uniqueTitle = Guid.NewGuid().ToString();
            string uniqueContent = $"Content_{uniqueTitle}";

            // Create the post JSON request body
            string postJson = $"{{\"Title\":\"{uniqueTitle}\",\"Content\":\"{uniqueContent}\"}}";

            // Send the POST request to add a post without authorization header
            HttpResponseMessage response = await _httpClient.PostAsync("/api/Post",
                new StringContent(postJson, Encoding.UTF8, "application/json"));

            // Check if the request was successful
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public async Task Backend_TestGetAllPosts()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/api/Post");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            string responseBody = await response.Content.ReadAsStringAsync();
            var posts = JsonConvert.DeserializeObject<List<Post>>(responseBody);
            Assert.IsNotNull(posts);
        }

        [Test]
        public async Task Backend_TestDeletePost()
        {
            // Generate unique identifiers
            string uniqueId = Guid.NewGuid().ToString();
            string uniqueTitle = $"PostTitle_{uniqueId}";
            string uniqueContent = $"PostContent_{uniqueId}";

            // Create a post to delete
            var initialPostDetails = new
            {
                Title = uniqueTitle,
                Content = uniqueContent
            };

            string initialPostRequestBody = JsonConvert.SerializeObject(initialPostDetails);
            HttpResponseMessage addPostResponse = await _httpClient.PostAsync("/api/Post", new StringContent(initialPostRequestBody, Encoding.UTF8, "application/json"));
            Assert.AreEqual(HttpStatusCode.OK, addPostResponse.StatusCode);

            // Get the added post details
            string addPostResponseBody = await addPostResponse.Content.ReadAsStringAsync();
            dynamic addPostResponseMap = JsonConvert.DeserializeObject(addPostResponseBody);

            // Extract the postId for deletion
            int? postId = addPostResponseMap?.id;
            Console.WriteLine(postId);

            if (postId.HasValue)
            {
                // Delete the post
                HttpResponseMessage deletePostResponse = await _httpClient.DeleteAsync($"/api/Post/{postId}");

                // Assert that the post is deleted successfully
                Assert.AreEqual(HttpStatusCode.NoContent, deletePostResponse.StatusCode);
            }
            else
            {
                // Log additional information for debugging
                string responseContent = await addPostResponse.Content.ReadAsStringAsync();
                Console.WriteLine($"Add Post Response Content: {responseContent}");

                Assert.Fail("Post ID is null or not found in the response.");
            }
        }

        [Test]
        public async Task Backend_TestAddComment()
        {
            // Create a unique title and content for the post
            string uniquePostTitle = Guid.NewGuid().ToString();
            string uniquePostContent = $"Content_{uniquePostTitle}";

            // Create the post JSON request body
            string postJson = $"{{\"Title\":\"{uniquePostTitle}\",\"Content\":\"{uniquePostContent}\"}}";

            // Send the POST request to add a post
            HttpResponseMessage addPostResponse = await _httpClient.PostAsync("/api/Post",
                new StringContent(postJson, Encoding.UTF8, "application/json"));
            
            // Check if the request was successful
            Assert.AreEqual(HttpStatusCode.OK, addPostResponse.StatusCode);

            // Get the added post details
            string addPostResponseBody = await addPostResponse.Content.ReadAsStringAsync();
            dynamic addPostResponseMap = JsonConvert.DeserializeObject(addPostResponseBody);

            // Extract the postId for adding a comment
            int? postId = addPostResponseMap?.id;

            if (postId.HasValue)
            {
                // Create a unique comment text
                string uniqueCommentText = Guid.NewGuid().ToString();

                // Create the comment JSON request body
                string commentJson = $"{{\"Text\":\"{uniqueCommentText}\"}}";

                // Send the POST request to add a comment to the post
                HttpResponseMessage addCommentResponse = await _httpClient.PostAsync($"/api/posts/{postId}/comments",
                    new StringContent(commentJson, Encoding.UTF8, "application/json"));

                // Check if the request was successful
                Assert.AreEqual(HttpStatusCode.Created, addCommentResponse.StatusCode);
            }
            else
            {
                // Log additional information for debugging
                string responseContent = await addPostResponse.Content.ReadAsStringAsync();
                Console.WriteLine($"Add Post Response Content: {responseContent}");

                Assert.Fail("Post ID is null or not found in the response.");
            }
        }

        [Test]
        public async Task Backend_TestGetAllComments()
        {
            // Create a unique title and content for the post
            string uniquePostTitle = Guid.NewGuid().ToString();
            string uniquePostContent = $"Content_{uniquePostTitle}";

            // Create the post JSON request body
            string postJson = $"{{\"Title\":\"{uniquePostTitle}\",\"Content\":\"{uniquePostContent}\"}}";

            // Send the POST request to add a post
            HttpResponseMessage addPostResponse = await _httpClient.PostAsync("/api/Post",
                new StringContent(postJson, Encoding.UTF8, "application/json"));
            
            // Check if the request was successful
            Assert.AreEqual(HttpStatusCode.OK, addPostResponse.StatusCode);

            // Get the added post details
            string addPostResponseBody = await addPostResponse.Content.ReadAsStringAsync();
            dynamic addPostResponseMap = JsonConvert.DeserializeObject(addPostResponseBody);

            // Extract the postId for getting comments
            int? postId = addPostResponseMap?.id;

            if (postId.HasValue)
            {
                // Send the GET request to get all comments for the post
                HttpResponseMessage getAllCommentsResponse = await _httpClient.GetAsync($"/api/posts/{postId}/comments");

                // Check if the request was successful
                Assert.AreEqual(HttpStatusCode.OK, getAllCommentsResponse.StatusCode);

                // Get the comments from the response
                string getAllCommentsResponseBody = await getAllCommentsResponse.Content.ReadAsStringAsync();
                var comments = JsonConvert.DeserializeObject<List<Comment>>(getAllCommentsResponseBody);

                // Ensure that the retrieved comments are not null
                Assert.NotNull(comments);
            }
            else
            {
                // Log additional information for debugging
                string responseContent = await addPostResponse.Content.ReadAsStringAsync();
                Console.WriteLine($"Add Post Response Content: {responseContent}");

                Assert.Fail("Post ID is null or not found in the response.");
            }
        }

        [Test]
        public async Task Backend_TestDeleteComment()
        {
            // Create a unique title and content for the post
            string uniquePostTitle = Guid.NewGuid().ToString();
            string uniquePostContent = $"Content_{uniquePostTitle}";

            // Create the post JSON request body
            string postJson = $"{{\"Title\":\"{uniquePostTitle}\",\"Content\":\"{uniquePostContent}\"}}";

            // Send the POST request to add a post
            HttpResponseMessage addPostResponse = await _httpClient.PostAsync("/api/Post",
                new StringContent(postJson, Encoding.UTF8, "application/json"));

            // Check if the request was successful
            Assert.AreEqual(HttpStatusCode.OK, addPostResponse.StatusCode);

            // Get the added post details
            string addPostResponseBody = await addPostResponse.Content.ReadAsStringAsync();
            dynamic addPostResponseMap = JsonConvert.DeserializeObject(addPostResponseBody);

            // Extract the postId for adding a comment
            int? postId = addPostResponseMap?.id;

            if (postId.HasValue)
            {
                // Create a unique comment text
                string uniqueCommentText = Guid.NewGuid().ToString();

                // Create the comment JSON request body
                string commentJson = $"{{\"Text\":\"{uniqueCommentText}\"}}";

                // Send the POST request to add a comment to the post
                HttpResponseMessage addCommentResponse = await _httpClient.PostAsync($"/api/posts/{postId}/comments",
                    new StringContent(commentJson, Encoding.UTF8, "application/json"));

                // Check if the request was successful
                Assert.AreEqual(HttpStatusCode.Created, addCommentResponse.StatusCode);

                // Get the added comment details
                string addCommentResponseBody = await addCommentResponse.Content.ReadAsStringAsync();
                dynamic addCommentResponseMap = JsonConvert.DeserializeObject(addCommentResponseBody);

                // Extract the commentId for deletion
                int? commentId = addCommentResponseMap?.id;

                if (commentId.HasValue)
                {
                    // Send the DELETE request to delete the comment
                    HttpResponseMessage deleteCommentResponse = await _httpClient.DeleteAsync($"/api/posts/{postId}/comments/{commentId}");

                    // Check if the request was successful
                    Assert.AreEqual(HttpStatusCode.NoContent, deleteCommentResponse.StatusCode);
                }
                else
                {
                    // Log additional information for debugging
                    string responseContent = await addCommentResponse.Content.ReadAsStringAsync();
                    Console.WriteLine($"Add Comment Response Content: {responseContent}");

                    Assert.Fail("Comment ID is null or not found in the response.");
                }
            }
            else
            {
                // Log additional information for debugging
                string responseContent = await addPostResponse.Content.ReadAsStringAsync();
                Console.WriteLine($"Add Post Response Content: {responseContent}");

                Assert.Fail("Post ID is null or not found in the response.");
            }
        }

}
}