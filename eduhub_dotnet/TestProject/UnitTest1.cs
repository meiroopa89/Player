using dotnetapp.Exceptions;
using dotnetapp.Models;
using dotnetapp.Data;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;
using System.Reflection;
using dotnetapp.Services;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;

namespace dotnetapp.Tests
{
    [TestFixture]
    public class Tests
    {

        private ApplicationDbContext _context; 
        private HttpClient _httpClient;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "TestDatabase").Options;
            _context = new ApplicationDbContext(options);
           
             _httpClient = new HttpClient();
             _httpClient.BaseAddress = new Uri("http://localhost:8080");

        }

        [TearDown]
        public void TearDown()
        {
             _context.Dispose();
        }

[Test, Order(1)]
public async Task Backend_Test_Post_Method_Register_Educator_Returns_HttpStatusCode_OK()
    {
        ClearDatabase();
        string uniqueId = Guid.NewGuid().ToString();

        // Generate a unique userName based on a timestamp
        string uniqueUsername = $"abcd_{uniqueId}";
        string uniqueEmail = $"abcd{uniqueId}@gmail.com";

        string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Educator\"}}";
        HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));

        Console.WriteLine(response.StatusCode);
        string responseString = await response.Content.ReadAsStringAsync();

        Console.WriteLine(responseString);
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    }
  
[Test, Order(2)]
public async Task Backend_Test_Post_Method_Login_Student_Returns_HttpStatusCode_OK()
    {
        ClearDatabase();

        string uniqueId = Guid.NewGuid().ToString();

        // Generate a unique userName based on a timestamp
        string uniqueUsername = $"abcd_{uniqueId}";
        string uniqueEmail = $"abcd{uniqueId}@gmail.com";

        string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Student\"}}";
        HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));

        // Print registration response
        string registerResponseBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine("Registration Response: " + registerResponseBody);

        // Login with the registered user
        string loginRequestBody = $"{{\"Email\" : \"{uniqueEmail}\",\"Password\" : \"abc@123A\"}}"; // Updated variable names
        HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));

        // Print login response
        string loginResponseBody = await loginResponse.Content.ReadAsStringAsync();
        Console.WriteLine("Login Response: " + loginResponseBody);

        Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
    }
[Test, Order(3)]
public async Task Backend_Test_Get_All_Feedbacks_With_Token_By_Owner_Returns_HttpStatusCode_OK()
{
    ClearDatabase();
    string uniqueId = Guid.NewGuid().ToString();

    // Generate a unique userName based on a timestamp
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniqueEmail = $"abcd{uniqueId}@gmail.com";

    string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Educator\"}}";
    HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));

    // Print registration response
    string registerResponseBody = await response.Content.ReadAsStringAsync();
    Console.WriteLine("Registration Response: " + registerResponseBody);

    // Login with the registered user
    string loginRequestBody = $"{{\"Email\" : \"{uniqueEmail}\",\"Password\" : \"abc@123A\"}}"; // Updated variable names
    HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));

    // Print login response
    string loginResponseBody = await loginResponse.Content.ReadAsStringAsync();
    Console.WriteLine("Login Response: " + loginResponseBody);

    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
    string responseBody = await loginResponse.Content.ReadAsStringAsync();

    dynamic responseMap = JsonConvert.DeserializeObject(responseBody);

    string token = responseMap.token;

    Assert.IsNotNull(token);

    // Use the token to get all feeds
    _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
    HttpResponseMessage feedResponse = await _httpClient.GetAsync("/api/feedback");

    // Print feed response
    string feedResponseBody = await feedResponse.Content.ReadAsStringAsync();
    Console.WriteLine("Feed Response: " + feedResponseBody);

    Assert.AreEqual(HttpStatusCode.OK, feedResponse.StatusCode);
}

[Test, Order(4)]
public async Task Backend_Test_Get_All_Courses_Without_Token_By_Owner_Returns_HttpStatusCode_Unauthorized()
{
    ClearDatabase();
    string uniqueId = Guid.NewGuid().ToString();

    // Generate a unique userName based on a timestamp
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniqueEmail = $"abcd{uniqueId}@gmail.com";

    string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Student\"}}";
    HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));

    // Print registration response
    string registerResponseBody = await response.Content.ReadAsStringAsync();
    Console.WriteLine("Registration Response: " + registerResponseBody);

    // Login with the registered user
    string loginRequestBody = $"{{\"Email\" : \"{uniqueEmail}\",\"Password\" : \"abc@123A\"}}"; // Updated variable names
    HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));

    // Print login response
    string loginResponseBody = await loginResponse.Content.ReadAsStringAsync();
    Console.WriteLine("Login Response: " + loginResponseBody);

    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
    string responseBody = await loginResponse.Content.ReadAsStringAsync();

    HttpResponseMessage feedResponse = await _httpClient.GetAsync("/api/course");

    // Print feed response
    string feedResponseBody = await feedResponse.Content.ReadAsStringAsync();
    Console.WriteLine("Feed Response: " + feedResponseBody);

    Assert.AreEqual(HttpStatusCode.Unauthorized, feedResponse.StatusCode);
}



 [Test, Order(5)]
public async Task Backend_Test_Get_Method_Get_CourseById_In_Course_Service_Fetches_Course_Successfully()
        {
            ClearDatabase();

            var courseData = new Dictionary<string, object>
            {
                { "CourseId", 1 },
                { "Title", "Quality Course" },
                { "Description", "High quality course for students" },
                { "CourseStartDate", DateTime.Now },
                { "CourseEndDate", DateTime.Now.AddMonths(1) },
                { "Category", "Science" },
                { "Level", "Beginner" }
            };

            var course = new Course();
            foreach (var kvp in courseData)
            {
                var propertyInfo = typeof(Course).GetProperty(kvp.Key);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(course, kvp.Value);
                }
            }
            _context.Courses.Add(course);
            _context.SaveChanges();

            // Load assembly and types
            string assemblyName = "dotnetapp";
            Assembly assembly = Assembly.Load(assemblyName);
            string serviceName = "dotnetapp.Services.CourseService";

            Type serviceType = assembly.GetType(serviceName);

            // Get the GetCourseById method
            MethodInfo getCourseByIdMethod = serviceType.GetMethod("GetCourseById");

            if (getCourseByIdMethod != null)
            {
                var service = Activator.CreateInstance(serviceType, _context);
                var retrievedCourseTask = (Task<Course>)getCourseByIdMethod.Invoke(service, new object[] { 1 });
                var result = await retrievedCourseTask;

                // Assert the retrieved course is not null and properties match
                Assert.IsNotNull(result);
                Assert.AreEqual(course.Title, result.Title);
            }
            else
            {
                Assert.Fail();
            }
        }

[Test, Order(6)]
public async Task Backend_Test_Put_Method_UpdateCourse_In_Course_Service_Updates_Course_Successfully()
        {
            ClearDatabase();

            var courseData = new Dictionary<string, object>
            {
                { "CourseId", 1 },
                { "Title", "Quality Course" },
                { "Description", "High quality course for students" },
                { "CourseStartDate", DateTime.Now },
                { "CourseEndDate", DateTime.Now.AddMonths(1) },
                { "Category", "Science" },
                { "Level", "Beginner" }
            };

            var course = new Course();
            foreach (var kvp in courseData)
            {
                var propertyInfo = typeof(Course).GetProperty(kvp.Key);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(course, kvp.Value);
                }
            }
            _context.Courses.Add(course);
            _context.SaveChanges();

            // Load assembly and types
            string assemblyName = "dotnetapp";
            Assembly assembly = Assembly.Load(assemblyName);
            string serviceName = "dotnetapp.Services.CourseService";

            Type serviceType = assembly.GetType(serviceName);

            // Get the UpdateCourse method
            MethodInfo updateCourseMethod = serviceType.GetMethod("UpdateCourse", new[] { typeof(int), typeof(Course) });

            if (updateCourseMethod != null)
            {
                var service = Activator.CreateInstance(serviceType, _context);

                var updatedCourseData = new Dictionary<string, object>
                {
                    { "CourseId", 1 },
                    { "Title", "Updated Quality Course" },
                    { "Description", "Updated high quality course for students" },
                    { "CourseStartDate", DateTime.Now },
                    { "CourseEndDate", DateTime.Now.AddMonths(2) },
                    { "Category", "Math" },
                    { "Level", "Intermediate" }
                };

                var updatedCourse = new Course();
                foreach (var kvp in updatedCourseData)
                {
                    var propertyInfo = typeof(Course).GetProperty(kvp.Key);
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(updatedCourse, kvp.Value);
                    }
                }

                // Invoke UpdateCourse method
                var updateResultTask = (Task<bool>)updateCourseMethod.Invoke(service, new object[] { 1, updatedCourse });
                var updateResult = await updateResultTask;

                // Assert the update result
                Assert.IsTrue(updateResult);

                // Retrieve updated course from database
                var updatedCourseFromDb = await _context.Courses.FindAsync(1);

                // Assert the updated course properties
                Assert.IsNotNull(updatedCourseFromDb);
                Assert.AreEqual("Updated Quality Course", updatedCourseFromDb.Title);
                Assert.AreEqual("Updated high quality course for students", updatedCourseFromDb.Description);
                Assert.AreEqual("Math", updatedCourseFromDb.Category);
                Assert.AreEqual("Intermediate", updatedCourseFromDb.Level);
            }
            else
            {
                Assert.Fail();
            }
        }

[Test, Order(7)]
public async Task Backend_Test_Delete_Method_DeleteCourse_In_Course_Service_Deletes_Course_Successfully()
 {
            ClearDatabase();

            var courseData = new Dictionary<string, object>
            {
                { "CourseId", 1 },
                { "Title", "Quality Course" },
                { "Description", "High quality course for students" },
                { "CourseStartDate", DateTime.Now },
                { "CourseEndDate", DateTime.Now.AddMonths(1) },
                { "Category", "Science" },
                { "Level", "Beginner" }
            };

            var course = new Course();
            foreach (var kvp in courseData)
            {
                var propertyInfo = typeof(Course).GetProperty(kvp.Key);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(course, kvp.Value);
                }
            }
            _context.Courses.Add(course);
            _context.SaveChanges();

            // Load assembly and types
            string assemblyName = "dotnetapp";
            Assembly assembly = Assembly.Load(assemblyName);
            string serviceName = "dotnetapp.Services.CourseService";

            Type serviceType = assembly.GetType(serviceName);

            // Get the DeleteCourse method
            MethodInfo deleteCourseMethod = serviceType.GetMethod("DeleteCourse", new[] { typeof(int) });

            if (deleteCourseMethod != null)
            {
                var service = Activator.CreateInstance(serviceType, _context);

                // Invoke DeleteCourse method
                var deleteResultTask = (Task<bool>)deleteCourseMethod.Invoke(service, new object[] { 1 });
                var deleteResult = await deleteResultTask;

                // Assert the delete result
                Assert.IsTrue(deleteResult);

                // Retrieve deleted course from database
                var deletedCourseFromDb = await _context.Courses.FindAsync(1);

                // Assert the course is deleted
                Assert.IsNull(deletedCourseFromDb);
            }
            else
            {
                Assert.Fail();
            }
        }

[Test, Order(8)]
public async Task Backend_Test_Get_Method_GetMaterialById_In_MaterialService_Fetches_Material_Successfully()
{
    ClearDatabase();

    // Add a course to context
    var courseData = new Dictionary<string, object>
    {
        { "CourseId", 11 },
        { "Title", "Test Course" },
        { "Description", "Description for Test Course" },
        { "CourseStartDate", DateTime.Now },
        { "CourseEndDate", DateTime.Now.AddMonths(1) },
        { "Category", "Category 1" },
        { "Level", "Beginner" }
    };

    var course = new Course();
    foreach (var kvp in courseData)
    {
        var propertyInfo = typeof(Course).GetProperty(kvp.Key);
        if (propertyInfo != null)
        {
            propertyInfo.SetValue(course, kvp.Value);
        }
    }
    _context.Courses.Add(course);
    _context.SaveChanges();

    // Set up initial material data
    var materialData = new Dictionary<string, object>
    {
        { "MaterialId", 15 },
        { "CourseId", 11 },
        { "Title", "Material 1" },
        { "Description", "Description for Material 1" },
        { "URL", "http://example.com/material1" },
        { "UploadDate", DateTime.Now },
        { "ContentType", "PDF" }
    };

    var material = new Material();
    foreach (var kvp in materialData)
    {
        var propertyInfo = typeof(Material).GetProperty(kvp.Key);
        if (propertyInfo != null)
        {
            propertyInfo.SetValue(material, kvp.Value);
        }
    }
    _context.Materials.Add(material);
    _context.SaveChanges();

    // Load assembly and types
    string assemblyName = "dotnetapp";
    Assembly assembly = Assembly.Load(assemblyName);
    string serviceName = "dotnetapp.Services.MaterialService";

    Type serviceType = assembly.GetType(serviceName);

    // Get DeleteMaterial method

        MethodInfo getMeterialByIdMethod = serviceType.GetMethod("GetMaterialById");

            if (getMeterialByIdMethod != null)
            {
                var service = Activator.CreateInstance(serviceType, _context);
                var retrievedMaterialTask = (Task<Material>)getMeterialByIdMethod.Invoke(service, new object[] { 15 });
                var result = await retrievedMaterialTask;

                // Assert the retrieved course is not null and properties match
                Assert.IsNotNull(result);
                Assert.AreEqual(material.Title, result.Title);
            }
            else
            {
                Assert.Fail();
            }
}

[Test, Order(9)]
public async Task Backend_Test_Delete_Method_DeleteMaterial_In_MaterialService_Deletes_Material_Successfully()
{
    ClearDatabase();

    // Add a course to context
    var courseData = new Dictionary<string, object>
    {
        { "CourseId", 100 },
        { "Title", "Test Course" },
        { "Description", "Description for Test Course" },
        { "CourseStartDate", DateTime.Now },
        { "CourseEndDate", DateTime.Now.AddMonths(1) },
        { "Category", "Category 1" },
        { "Level", "Beginner" }
    };

    var course = new Course();
    foreach (var kvp in courseData)
    {
        var propertyInfo = typeof(Course).GetProperty(kvp.Key);
        if (propertyInfo != null)
        {
            propertyInfo.SetValue(course, kvp.Value);
        }
    }
    _context.Courses.Add(course);
    _context.SaveChanges();

    // Set up initial material data
    var materialData = new Dictionary<string, object>
    {
        { "MaterialId", 1 },
        { "CourseId", 100 },
        { "Title", "Material 1" },
        { "Description", "Description for Material 1" },
        { "URL", "http://example.com/material1" },
        { "UploadDate", DateTime.Now },
        { "ContentType", "PDF" }
    };

    var material = new Material();
    foreach (var kvp in materialData)
    {
        var propertyInfo = typeof(Material).GetProperty(kvp.Key);
        if (propertyInfo != null)
        {
            propertyInfo.SetValue(material, kvp.Value);
        }
    }
    _context.Materials.Add(material);
    _context.SaveChanges();

    // Load assembly and types
    string assemblyName = "dotnetapp";
    Assembly assembly = Assembly.Load(assemblyName);
    string serviceName = "dotnetapp.Services.MaterialService";

    Type serviceType = assembly.GetType(serviceName);

    // Get DeleteMaterial method
    MethodInfo deleteMaterialMethod = serviceType.GetMethod("DeleteMaterial");

    if (deleteMaterialMethod != null)
    {
        var service = Activator.CreateInstance(serviceType, _context);

        // Invoke DeleteMaterial method
        var deleteResult = (Task<bool>)deleteMaterialMethod.Invoke(service, new object[] { 1 });
        var isDeleted = await deleteResult;

        // Assert the results
        Assert.IsTrue(isDeleted);

        var deletedMaterialFromDb = await _context.Materials.FindAsync(1);
        Assert.IsNull(deletedMaterialFromDb);
    }
    else
    {
        Assert.Fail("DeleteMaterial method not found.");
    }
}


[Test, Order(10)]
public async Task Backend_Test_AddCourse_Throws_CourseException_For_Duplicate_Course()
        {
            // Clear the database
            ClearDatabase();
            string assemblyName = "dotnetapp";
            Assembly assembly = Assembly.Load(assemblyName);
            string serviceName = "dotnetapp.Services.CourseService";
            string typeName = "dotnetapp.Models.Course";

            Type serviceType = assembly.GetType(serviceName);
            Type modelType = assembly.GetType(typeName);

            MethodInfo method = serviceType.GetMethod("AddCourse", new[] { modelType });

            if (method != null)
            {
                var courseData = new Dictionary<string, object>
                {
                    { "CourseId", 1 },
                    { "Title", "Mathematics" },
                    { "Description", "Basic Mathematics" },
                    { "CourseStartDate", DateTime.Now },
                    { "CourseEndDate", DateTime.Now.AddDays(30) },
                    { "Category", "Math" },
                    { "Level", "Beginner" }
                };

                var course = Activator.CreateInstance(modelType);
                foreach (var kvp in courseData)
                {
                    var propertyInfo = modelType.GetProperty(kvp.Key);
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(course, kvp.Value);
                    }
                }

                var service = Activator.CreateInstance(serviceType, _context);
                var result = (Task<bool>)method.Invoke(service, new object[] { course });
                var addedCourse = await _context.Courses.FindAsync(1);
                Assert.IsNotNull(addedCourse);

                var duplicateCourseData = new Dictionary<string, object>
                {
                    { "CourseId", 2 },
                    { "Title", "Mathematics" },
                    { "Description", "Basic Mathematics" },
                    { "CourseStartDate", DateTime.Now },
                    { "CourseEndDate", DateTime.Now.AddDays(30) },
                    { "Category", "Math" },
                    { "Level", "Beginner" }
                };

                var duplicateCourse = Activator.CreateInstance(modelType);
                foreach (var kvp in duplicateCourseData)
                {
                    var propertyInfo = modelType.GetProperty(kvp.Key);
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(duplicateCourse, kvp.Value);
                    }
                }

                try
                {
                    var result1 = (Task<bool>)method.Invoke(service, new object[] { duplicateCourse });
                    Console.WriteLine("res" + result1.Result);
                    Assert.Fail();
                }
                catch (Exception ex)
                {
                    Assert.IsNotNull(ex.InnerException);
                    Assert.IsTrue(ex.InnerException is CourseException);
                    Assert.AreEqual("A course with the same name already exists", ex.InnerException.Message);
                }
            }
            else
            {
                Assert.Fail();
            }
        }

[Test, Order(11)]
public async Task Backend_Test_Post_Method_AddFeedback_In_Feedback_Service_Posts_Successfully()
{
        ClearDatabase();

    // Add user
    var userData = new Dictionary<string, object>
    {
        { "UserId",42 },
        { "Username", "testuser" },
        { "Password", "testpassword" },
        { "Email", "test@example.com" },
        { "MobileNumber", "1234567890" },
        { "UserRole", "Sudent" }
    };

    var user = new User();
    foreach (var kvp in userData)
    {
        var propertyInfo = typeof(User).GetProperty(kvp.Key);
        if (propertyInfo != null)
        {
            propertyInfo.SetValue(user, kvp.Value);
        }
    }
    _context.Users.Add(user);
    _context.SaveChanges();
    // Add loan application
    string assemblyName = "dotnetapp";
    Assembly assembly = Assembly.Load(assemblyName);
    string ServiceName = "dotnetapp.Services.FeedbackService";
    string typeName = "dotnetapp.Models.Feedback";

    Type serviceType = assembly.GetType(ServiceName);
    Type modelType = assembly.GetType(typeName);

    MethodInfo method = serviceType.GetMethod("AddFeedback", new[] { modelType });

    if (method != null)
    {
           var feedbackData = new Dictionary<string, object>
            {
                { "FeedbackId", 11 },
                { "UserId", 42 },
                { "FeedbackText", "Great experience!" },
                { "Date", DateTime.Now }
            };
        var feedback = new Feedback();
        foreach (var kvp in feedbackData)
        {
            var propertyInfo = typeof(Feedback).GetProperty(kvp.Key);
            if (propertyInfo != null)
            {
                propertyInfo.SetValue(feedback, kvp.Value);
            }
        }
        var service = Activator.CreateInstance(serviceType, _context);
        var result = (Task<bool>)method.Invoke(service, new object[] { feedback });
    
        var addedFeedback= await _context.Feedbacks.FindAsync(11);
        Assert.IsNotNull(addedFeedback);
        Assert.AreEqual("Great experience!",addedFeedback.FeedbackText);

    }
    else{
        Assert.Fail();
    }
}

[Test, Order(12)]
public async Task Backend_Test_Delete_Method_Feedback_In_Feeback_Service_Deletes_Successfully()
{
    // Add user
     ClearDatabase();

    var userData = new Dictionary<string, object>
    {
        { "UserId",42 },
        { "Username", "testuser" },
        { "Password", "testpassword" },
        { "Email", "test@example.com" },
        { "MobileNumber", "1234567890" },
        { "UserRole", "Student" }
    };

    var user = new User();
    foreach (var kvp in userData)
    {
        var propertyInfo = typeof(User).GetProperty(kvp.Key);
        if (propertyInfo != null)
        {
            propertyInfo.SetValue(user, kvp.Value);
        }
    }
    _context.Users.Add(user);
    _context.SaveChanges();

           var feedbackData = new Dictionary<string, object>
            {
                { "FeedbackId", 11 },
                { "UserId", 42 },
                { "FeedbackText", "Great experience!" },
                { "Date", DateTime.Now }
            };
        var feedback = new Feedback();
        foreach (var kvp in feedbackData)
        {
            var propertyInfo = typeof(Feedback).GetProperty(kvp.Key);
            if (propertyInfo != null)
            {
                propertyInfo.SetValue(feedback, kvp.Value);
            }
        }
     _context.Feedbacks.Add(feedback);
    _context.SaveChanges();
    // Add loan application
    string assemblyName = "dotnetapp";
    Assembly assembly = Assembly.Load(assemblyName);
    string ServiceName = "dotnetapp.Services.FeedbackService";
    string typeName = "dotnetapp.Models.Feedback";

    Type serviceType = assembly.GetType(ServiceName);
    Type modelType = assembly.GetType(typeName);

  
    MethodInfo deletemethod = serviceType.GetMethod("DeleteFeedback", new[] { typeof(int) });

    if (deletemethod != null)
    {
        var service = Activator.CreateInstance(serviceType, _context);
        var deleteResult = (Task<bool>)deletemethod.Invoke(service, new object[] { 11 });

        var deletedFeedbackFromDb = await _context.Feedbacks.FindAsync(11);
        Assert.IsNull(deletedFeedbackFromDb);
    }
    else
    {
        Assert.Fail();
    }
}

[Test, Order(13)]
public async Task Backend_Test_Get_Method_GetFeedbacksByUserId_In_Feedback_Service_Fetches_Successfully()
{
    ClearDatabase();

    // Add user
    var userData = new Dictionary<string, object>
    {
        { "UserId", 330 },
        { "Username", "testuser" },
        { "Password", "testpassword" },
        { "Email", "test@example.com" },
        { "MobileNumber", "1234567890" },
        { "UserRole", "Student" }
    };

    var user = new User();
    foreach (var kvp in userData)
    {
        var propertyInfo = typeof(User).GetProperty(kvp.Key);
        if (propertyInfo != null)
        {
            propertyInfo.SetValue(user, kvp.Value);
        }
    }
    _context.Users.Add(user);
    _context.SaveChanges();

    var feedbackData= new Dictionary<string, object>
    {
        { "FeedbackId", 13 },
        { "UserId", 330 },
        { "FeedbackText", "Great experience!" },
        { "Date", DateTime.Now }
    };

    var feedback = new Feedback();
    foreach (var kvp in feedbackData)
    {
        var propertyInfo = typeof(Feedback).GetProperty(kvp.Key);
        if (propertyInfo != null)
        {
            propertyInfo.SetValue(feedback, kvp.Value);
        }
    }
    _context.Feedbacks.Add(feedback);
    _context.SaveChanges();

    // Add loan application
    string assemblyName = "dotnetapp";
    Assembly assembly = Assembly.Load(assemblyName);
    string ServiceName = "dotnetapp.Services.FeedbackService";
    string typeName = "dotnetapp.Models.Feedback";

    Type serviceType = assembly.GetType(ServiceName);
    Type modelType = assembly.GetType(typeName);

    MethodInfo method = serviceType.GetMethod("GetFeedbacksByUserId");

    if (method != null)
    {
        var service = Activator.CreateInstance(serviceType, _context);
        var result = ( Task<IEnumerable<Feedback>>)method.Invoke(service, new object[] {330});
        Assert.IsNotNull(result);
         var check=true;
        foreach (var item in result.Result)
        {
            check=false;
            Assert.AreEqual("Great experience!", item.FeedbackText);
   
        }
        if(check==true)
        {
            Assert.Fail();

        }
    }
    else{
        Assert.Fail();
    }
}

private void ClearDatabase()
{
    _context.Database.EnsureDeleted();
    _context.Database.EnsureCreated();
}

}
}

