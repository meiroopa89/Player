using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using dotnetapp.Models;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;


namespace TestProject;


[TestFixture]
public class Tests
{
    private HttpClient _httpClient;
    private string _generatedToken;

    [SetUp]
    public void Setup()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://8080-bfdeeddcedfabcfacbdcbaeadbebabcdebdca.premiumproject.examly.io/"); 
    }

[Test, Order(1)]
    public async Task Backend_TestRegisterUser()
    {
        string uniqueId = Guid.NewGuid().ToString();
 
        // Generate a unique userName based on a timestamp
        string uniqueUsername = $"abcd_{uniqueId}";
        string uniqueEmail = $"abcd{uniqueId}@gmail.com";
 
        string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Organizer\"}}";
        HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
 
        Console.WriteLine(response.StatusCode);
        string responseString = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseString);
 
        // Assuming you get a 200 OK status for successful registration
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    }

 
    [Test, Order(2)]
    public async Task Backend_TestLoginUser()
    {
        string uniqueId = Guid.NewGuid().ToString();
 
        string uniqueusername = $"abcd_{uniqueId}";
        string uniquepassword = $"abcdA{uniqueId}@123";
        string uniqueEmail = $"abcd{uniqueId}@gmail.com";
        string uniqueuserrole = "Organizer";
        string requestBody = $"{{\"Username\": \"{uniqueusername}\", \"Password\": \"{uniquepassword}\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\",\"UserRole\" : \"{uniqueuserrole}\" }}";
        HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
 
        string requestBody1 = $"{{\"email\": \"{uniqueEmail}\",\"password\": \"{uniquepassword}\"}}";
        HttpResponseMessage response1 = await _httpClient.PostAsync("/api/login", new StringContent(requestBody1, Encoding.UTF8, "application/json"));
        Assert.AreEqual(HttpStatusCode.OK, response1.StatusCode);
        string responseBody = await response1.Content.ReadAsStringAsync();
    }
 
    [Test, Order(3)]
    public async Task Backend_TestRegisterAdmin()
    {
        string uniqueId = Guid.NewGuid().ToString();
        string uniqueUsername = $"abcd_{uniqueId}";
        string uniqueEmail = $"abcd{uniqueId}@gmail.com";
 
        string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Admin\"}}";
       
        HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
 
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        string responseBody = await response.Content.ReadAsStringAsync();
        // Add your assertions based on the response if needed
    }
 
    [Test, Order(4)]
    public async Task Backend_TestLoginAdmin()
    {
        string uniqueId = Guid.NewGuid().ToString();
 
        string uniqueusername = $"abcd_{uniqueId}";
        string uniquepassword = $"abcdA{uniqueId}@123";
        string uniqueEmail = $"abcd{uniqueId}@gmail.com";
        string uniqueuserrole = "Admin";
        string requestBody = $"{{\"Username\": \"{uniqueusername}\", \"Password\": \"{uniquepassword}\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\",\"UserRole\" : \"{uniqueuserrole}\" }}";
        HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
 
        string requestBody1 = $"{{\"email\": \"{uniqueEmail}\",\"password\": \"{uniquepassword}\"}}";
        HttpResponseMessage response1 = await _httpClient.PostAsync("/api/login", new StringContent(requestBody1, Encoding.UTF8, "application/json"));
        Assert.AreEqual(HttpStatusCode.OK, response1.StatusCode);
        string responseBody = await response1.Content.ReadAsStringAsync();
    }

[Test]
public async Task Backend_TestAddTransaction()
{
    HttpResponseMessage response = null;

    // Register a new customer and obtain the authentication token
    string uniqueId = Guid.NewGuid().ToString();
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniquePassword = $"abcdA{uniqueId}@123";
    string uniqueEmail = $"abcd{uniqueId}@gmail.com";

    // Register a new customer
    string registerRequestBody = $"{{\"password\": \"{uniquePassword}\", \"userName\": \"{uniqueUsername}\",\"role\": \"customer\",\"email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\"}}";
    HttpResponseMessage registrationResponse = await _httpClient.PostAsync("/api/register", new StringContent(registerRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, registrationResponse.StatusCode);

    // Log in the registered customer and obtain the authentication token
    string loginRequestBody = $"{{\"Email\": \"{uniqueEmail}\", \"Password\": \"{uniquePassword}\"}}";
    HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);

    string responseString = await loginResponse.Content.ReadAsStringAsync();
    dynamic responseMap = JsonConvert.DeserializeObject(responseString);
    string customerAuthToken = responseMap.token;

    // Set the authentication token in the HTTP client headers
    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", customerAuthToken);

    // Create a transaction object
    var transaction = new
    {
        AccountId = 1, // Assuming you have a valid account ID
        Type = "Credit",
        Amount = 100.0m,
        Timestamp = DateTime.UtcNow
    };

    try
    {
        string requestBody = JsonConvert.SerializeObject(transaction);
        response = await _httpClient.PostAsync("/api/transaction", new StringContent(requestBody, Encoding.UTF8, "application/json"));

        // Assert that the transaction was successfully added
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        // Additional assertions based on the properties of the added transaction
        string responseContent = await response.Content.ReadAsStringAsync();
        dynamic addedTransaction = JsonConvert.DeserializeObject(responseContent);

        // Assert specific properties of the added transaction
        Assert.IsNotNull(addedTransaction.TransactionId);
        Assert.AreEqual(transaction.AccountId, Convert.ToInt64(addedTransaction.AccountId));
        Assert.AreEqual(transaction.Type, addedTransaction.Type.ToString());
        Assert.AreEqual(transaction.Amount, Convert.ToDecimal(addedTransaction.Amount));
        Assert.AreEqual(transaction.Timestamp, DateTime.Parse(addedTransaction.Timestamp.ToString()));
        // Add additional assertions for other properties if needed
    }
    catch (HttpRequestException ex)
    {
        Console.WriteLine($"Request failed: {ex.Message}");

        if (response != null)
        {
            // Print response content for debugging purposes
            Console.WriteLine($"Response Content: {await response.Content.ReadAsStringAsync()}");
        }

        throw;
    }
}

        [Test]
        public async Task Backend_TestGetAllEvents()
        {
            // Generate unique identifiers
            string uniqueId = Guid.NewGuid().ToString();
            string uniqueusername = $"abcd_{uniqueId}";
            string uniquepassword = $"abcdA{uniqueId}@123";
            string uniqueEmail = $"abcd{uniqueId}@gmail.com";

            // Register a customer
            string registerRequestBody = $"{{\"Username\": \"{uniqueusername}\", \"Password\": \"{uniquepassword}\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\",\"UserRole\" : \"Organizer\" }}";
            HttpResponseMessage registerResponse = await _httpClient.PostAsync("/api/register", new StringContent(registerRequestBody, Encoding.UTF8, "application/json"));
            Assert.AreEqual(HttpStatusCode.OK, registerResponse.StatusCode);

            // Login the registered customer
            string loginRequestBody = $"{{\"email\": \"{uniqueEmail}\",\"password\": \"{uniquepassword}\"}}";
            HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
            Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
            string loginResponseBody = await loginResponse.Content.ReadAsStringAsync();
            dynamic loginResponseMap = JsonConvert.DeserializeObject(loginResponseBody);
            string customerAuthToken = loginResponseMap.token;

            // Use the obtained token in the request to get events
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", customerAuthToken);

            // Make a request to get events
            HttpResponseMessage getEventsResponse = await _httpClient.GetAsync("api/event");
            Assert.AreEqual(HttpStatusCode.OK, getEventsResponse.StatusCode);

            // Validate the response content (assuming the response is a JSON array of events)
            string getEventsResponseBody = await getEventsResponse.Content.ReadAsStringAsync();
            var events = JsonConvert.DeserializeObject<List<Event>>(getEventsResponseBody);
            Assert.IsNotNull(events);
            Assert.IsTrue(events.Any());
        }

[Test]
public async Task Backend_TestGetEventById()
{
    // Generate unique identifiers
    string uniqueId = Guid.NewGuid().ToString();
    string uniqueusername = $"abcd_{uniqueId}";
    string uniquepassword = $"abcdA{uniqueId}@123";
    string uniqueEmail = $"abcd{uniqueId}@gmail.com";

    // Register a customer
    string registerRequestBody = $"{{\"Username\": \"{uniqueusername}\", \"Password\": \"{uniquepassword}\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\",\"UserRole\" : \"Organizer\" }}";
    HttpResponseMessage registerResponse = await _httpClient.PostAsync("/api/register", new StringContent(registerRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, registerResponse.StatusCode);

    // Login the registered customer
    string loginRequestBody = $"{{\"email\": \"{uniqueEmail}\",\"password\": \"{uniquepassword}\"}}";
    HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
    string loginResponseBody = await loginResponse.Content.ReadAsStringAsync();
    dynamic loginResponseMap = JsonConvert.DeserializeObject(loginResponseBody);
    string organizerAuthToken = loginResponseMap.token;

    // Use the obtained token in the request to get the organizer's event
    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", organizerAuthToken);

    // Make a request to get the events
    HttpResponseMessage getEventsResponse = await _httpClient.GetAsync("api/event");
    Assert.AreEqual(HttpStatusCode.OK, getEventsResponse.StatusCode);

    // Validate the response content (assuming the response is a JSON array of events)
    string getEventsResponseBody = await getEventsResponse.Content.ReadAsStringAsync();
    var events = JsonConvert.DeserializeObject<List<Event>>(getEventsResponseBody);
    Assert.IsNotNull(events);
    Assert.IsTrue(events.Any());

    // Get the first event ID from the response
    int eventId = events.First().EventId;

    // Make a request to get a specific event by ID
    HttpResponseMessage getEventByIdResponse = await _httpClient.GetAsync($"api/event/{eventId}");
    Assert.AreEqual(HttpStatusCode.OK, getEventByIdResponse.StatusCode);

    // Validate the response content for the specific event
    string getEventByIdResponseBody = await getEventByIdResponse.Content.ReadAsStringAsync();
    var specificEvent = JsonConvert.DeserializeObject<Event>(getEventByIdResponseBody);
    Assert.IsNotNull(specificEvent);
    Assert.AreEqual(eventId, specificEvent.EventId);
}

[Test]
public async Task Backend_TestUpdateEvent()
{
    // Generate unique identifiers
    string uniqueId = Guid.NewGuid().ToString();
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniquePassword = $"abcdA{uniqueId}@123";
    string uniqueEmail = $"abcd{uniqueId}@gmail.com";

    // Register an organizer
    string registerRequestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"{uniquePassword}\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\",\"UserRole\" : \"Organizer\" }}";
    HttpResponseMessage registerResponse = await _httpClient.PostAsync("/api/register", new StringContent(registerRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, registerResponse.StatusCode);

    // Login the registered organizer
    string loginRequestBody = $"{{\"email\": \"{uniqueEmail}\",\"password\": \"{uniquePassword}\"}}";
    HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
    string loginResponseBody = await loginResponse.Content.ReadAsStringAsync();
    dynamic loginResponseMap = JsonConvert.DeserializeObject(loginResponseBody);
    string organizerAuthToken = loginResponseMap.token;

    // Use the obtained token in the request to get the organizer's events
    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", organizerAuthToken);

    // Make a request to get the organizer's events
    HttpResponseMessage getEventsResponse = await _httpClient.GetAsync("api/event");
    Assert.AreEqual(HttpStatusCode.OK, getEventsResponse.StatusCode);

    // Validate the response content (assuming the response is a JSON array of events)
    string getEventsResponseBody = await getEventsResponse.Content.ReadAsStringAsync();
    var events = JsonConvert.DeserializeObject<List<Event>>(getEventsResponseBody);
    Assert.IsNotNull(events);
    Assert.IsTrue(events.Any());

    // Get the first event ID from the response
    int eventId= events.First().EventId;

    // Generate updated event data
    var updatedEvent = new Event
    {
        EventName = "Updated Event",
        StartDate = DateTime.UtcNow,
        EndDate = DateTime.UtcNow.AddDays(2),
        EventImageURL = "updated-image-url.jpg",
        Description = "Updated event description"
        // Add more properties as needed
    };

    // Make a request to update the event
    string updateEventRequestBody = JsonConvert.SerializeObject(updatedEvent);
    HttpResponseMessage updateEventResponse = await _httpClient.PutAsync($"api/event/{eventId}", new StringContent(updateEventRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, updateEventResponse.StatusCode);

    // Validate the response content
    string updateEventResponseBody = await updateEventResponse.Content.ReadAsStringAsync();
    dynamic updateEventResponseMap = JsonConvert.DeserializeObject(updateEventResponseBody);

    // Corrected assertion for the response message
    Assert.AreEqual("Event updated successfully", updateEventResponseMap.message.ToString());
}

[Test]
public async Task Backend_TestDeleteEvent()
{
    // Generate unique identifiers
    string uniqueId = Guid.NewGuid().ToString();
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniquePassword = $"abcdA{uniqueId}@123";
    string uniqueEmail = $"abcd{uniqueId}@gmail.com";

    // Register an organizer
    string registerRequestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"{uniquePassword}\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\",\"UserRole\" : \"Organizer\" }}";
    HttpResponseMessage registerResponse = await _httpClient.PostAsync("/api/register", new StringContent(registerRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, registerResponse.StatusCode);

    // Login the registered organizer
    string loginRequestBody = $"{{\"email\": \"{uniqueEmail}\",\"password\": \"{uniquePassword}\"}}";
    HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
    string loginResponseBody = await loginResponse.Content.ReadAsStringAsync();
    dynamic loginResponseMap = JsonConvert.DeserializeObject(loginResponseBody);
    string organizerAuthToken = loginResponseMap.token;

    // Use the obtained token in the request to get the organizer's events
    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", organizerAuthToken);

    // Make a request to get the organizer's events
    HttpResponseMessage getEventsResponse = await _httpClient.GetAsync("api/event");
    Assert.AreEqual(HttpStatusCode.OK, getEventsResponse.StatusCode);

    // Validate the response content (assuming the response is a JSON array of events)
    string getEventsResponseBody = await getEventsResponse.Content.ReadAsStringAsync();
    var events = JsonConvert.DeserializeObject<List<Event>>(getEventsResponseBody);
    Assert.IsNotNull(events);
    Assert.IsTrue(events.Any());

    // Get the first event ID from the response
    int eventIdToDelete = events.First().EventId;

    // Make a request to delete the event
    HttpResponseMessage deleteEventResponse = await _httpClient.DeleteAsync($"api/event/{eventIdToDelete}");
    Assert.AreEqual(HttpStatusCode.OK, deleteEventResponse.StatusCode);

    // Validate the response content
    string deleteEventResponseBody = await deleteEventResponse.Content.ReadAsStringAsync();
    dynamic deleteEventResponseMap = JsonConvert.DeserializeObject(deleteEventResponseBody);
    
    // Assert that the event was deleted successfully
    Assert.AreEqual("Event deleted successfully", deleteEventResponseMap.message.ToString());
}


[Test]
public async Task Backend_TestAddReferee()
{
    try
    {
        // Generate unique identifiers
        string uniqueId = Guid.NewGuid().ToString();
        string uniqueUsername = $"abcd_{uniqueId}";
        string uniquePassword = $"abcdA{uniqueId}@123";
        string uniqueEmail = $"abcd{uniqueId}@gmail.com";

        // Register an admin user
        string registerRequestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"{uniquePassword}\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\",\"UserRole\" : \"Admin\" }}";
        HttpResponseMessage registerResponse = await _httpClient.PostAsync("/api/register", new StringContent(registerRequestBody, Encoding.UTF8, "application/json"));
        Assert.AreEqual(HttpStatusCode.OK, registerResponse.StatusCode);

        // Login the registered admin
        string loginRequestBody = $"{{\"email\": \"{uniqueEmail}\",\"password\": \"{uniquePassword}\"}}";
        HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
        Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
        string loginResponseBody = await loginResponse.Content.ReadAsStringAsync();
        dynamic loginResponseMap = JsonConvert.DeserializeObject(loginResponseBody);
        string adminAuthToken = loginResponseMap.token;

        // Use the obtained token in the request to add a referee
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", adminAuthToken);

        var refereeToAdd = new
        {
            RefereeName = "John Doe",
            Country = "United States",
        };

        string refereeRequestBody = JsonConvert.SerializeObject(refereeToAdd);
        HttpResponseMessage refereeResponse = await _httpClient.PostAsync("api/referee", new StringContent(refereeRequestBody, Encoding.UTF8, "application/json"));

        // Check for successful status code
        Assert.AreEqual(HttpStatusCode.OK, refereeResponse.StatusCode);

        // Check for valid response content
        string refereeResponseBody = await refereeResponse.Content.ReadAsStringAsync();
        dynamic refereeResponseMap = JsonConvert.DeserializeObject(refereeResponseBody);

        Assert.AreEqual("Referee added successfully", refereeResponseMap.message.ToString());
    }
    catch (HttpRequestException httpEx)
    {
        // Log HTTP exception details
        Console.WriteLine($"HTTP Exception: {httpEx.Message}");
        if (httpEx.InnerException != null)
        {
            Console.WriteLine($"Inner Exception: {httpEx.InnerException.Message}");
        }

        // Re-throw the exception to mark the test as failed
        throw;
    }
    catch (Exception ex)
    {
        // Log general exception details
        Console.WriteLine($"Exception: {ex.Message}");
        Console.WriteLine($"StackTrace: {ex.StackTrace}");

        // Re-throw the exception to mark the test as failed
        throw;
    }
}

[Test]
public async Task Backend_TestGetAllReferees()
{
    try
    {
        // Generate unique identifiers
        string uniqueId = Guid.NewGuid().ToString();
        string uniqueUsername = $"abcd_{uniqueId}";
        string uniquePassword = $"abcdA{uniqueId}@123";
        string uniqueEmail = $"abcd{uniqueId}@gmail.com";

        // Register a user (assuming they have necessary permissions, e.g., Admin)
        string registerRequestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"{uniquePassword}\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\",\"UserRole\" : \"Admin\" }}";
        HttpResponseMessage registerResponse = await _httpClient.PostAsync("/api/register", new StringContent(registerRequestBody, Encoding.UTF8, "application/json"));
        Assert.AreEqual(HttpStatusCode.OK, registerResponse.StatusCode);

        // Login the registered user
        string loginRequestBody = $"{{\"email\": \"{uniqueEmail}\",\"password\": \"{uniquePassword}\"}}";
        HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
        Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
        string loginResponseBody = await loginResponse.Content.ReadAsStringAsync();
        dynamic loginResponseMap = JsonConvert.DeserializeObject(loginResponseBody);
        string userAuthToken = loginResponseMap.token;

        // Use the obtained token in the request to get all referees
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", userAuthToken);

        HttpResponseMessage getAllRefereesResponse = await _httpClient.GetAsync("api/referee");

        // Check for successful status code
        Assert.AreEqual(HttpStatusCode.OK, getAllRefereesResponse.StatusCode);

        // Check for valid response content
        string getAllRefereesResponseBody = await getAllRefereesResponse.Content.ReadAsStringAsync();
        var referees = JsonConvert.DeserializeObject<List<Referee>>(getAllRefereesResponseBody);

        // Assuming referees is a non-null list, you can perform further assertions as needed
        Assert.IsNotNull(referees);
        Assert.IsTrue(referees.Any());
    }
    catch (HttpRequestException httpEx)
    {
        // Log HTTP exception details
        Console.WriteLine($"HTTP Exception: {httpEx.Message}");
        if (httpEx.InnerException != null)
        {
            Console.WriteLine($"Inner Exception: {httpEx.InnerException.Message}");
        }

        // Re-throw the exception to mark the test as failed
        throw;
    }
    catch (Exception ex)
    {
        // Log general exception details
        Console.WriteLine($"Exception: {ex.Message}");
        Console.WriteLine($"StackTrace: {ex.StackTrace}");

        // Re-throw the exception to mark the test as failed
        throw;
    }
}

[Test]
public async Task Backend_TestGetAllSchedules()
{
    try
    {
        // Generate unique identifiers
        string uniqueId = Guid.NewGuid().ToString();
        string uniqueUsername = $"abcd_{uniqueId}";
        string uniquePassword = $"abcdA{uniqueId}@123";
        string uniqueEmail = $"abcd{uniqueId}@gmail.com";

        // Register an organizer user
        string registerRequestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"{uniquePassword}\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\",\"UserRole\" : \"Organizer\" }}";
        HttpResponseMessage registerResponse = await _httpClient.PostAsync("/api/register", new StringContent(registerRequestBody, Encoding.UTF8, "application/json"));
        Assert.AreEqual(HttpStatusCode.OK, registerResponse.StatusCode);

        // Login the registered organizer user
        string loginRequestBody = $"{{\"email\": \"{uniqueEmail}\",\"password\": \"{uniquePassword}\"}}";
        HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
        Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
        string loginResponseBody = await loginResponse.Content.ReadAsStringAsync();
        dynamic loginResponseMap = JsonConvert.DeserializeObject(loginResponseBody);
        string organizerAuthToken = loginResponseMap.token;

        // Use the obtained token in the request to get all schedules
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", organizerAuthToken);

        // Get all schedules
        HttpResponseMessage getAllSchedulesResponse = await _httpClient.GetAsync("/api/schedule");

        // Check for successful status code
        Assert.AreEqual(HttpStatusCode.OK, getAllSchedulesResponse.StatusCode);

        // Check for valid response content (assuming it returns a list of schedules)
        string schedulesResponseBody = await getAllSchedulesResponse.Content.ReadAsStringAsync();
        List<Schedule> schedules = JsonConvert.DeserializeObject<List<Schedule>>(schedulesResponseBody);

        // Assert that the returned list is not null
        Assert.IsNotNull(schedules);

        // You can add more specific assertions based on your application logic
    }
    catch (HttpRequestException httpEx)
    {
        // Log HTTP exception details
        Console.WriteLine($"HTTP Exception: {httpEx.Message}");
        if (httpEx.InnerException != null)
        {
            Console.WriteLine($"Inner Exception: {httpEx.InnerException.Message}");
        }

        // Re-throw the exception to mark the test as failed
        throw;
    }
    catch (Exception ex)
    {
        // Log general exception details
        Console.WriteLine($"Exception: {ex.Message}");
        Console.WriteLine($"StackTrace: {ex.StackTrace}");

        // Re-throw the exception to mark the test as failed
        throw;
    }
}


[Test]
public async Task Backend_TestAddTeam()
{
    try
    {
        // Generate unique identifiers
        string uniqueId = Guid.NewGuid().ToString();
        string uniqueUsername = $"abcd_{uniqueId}";
        string uniquePassword = $"abcdA{uniqueId}@123";
        string uniqueEmail = $"abcd{uniqueId}@gmail.com";

        // Register an admin user
        string registerRequestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"{uniquePassword}\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\",\"UserRole\" : \"Admin\" }}";
        HttpResponseMessage registerResponse = await _httpClient.PostAsync("/api/register", new StringContent(registerRequestBody, Encoding.UTF8, "application/json"));
        Assert.AreEqual(HttpStatusCode.OK, registerResponse.StatusCode);

        // Login the registered admin user
        string loginRequestBody = $"{{\"email\": \"{uniqueEmail}\",\"password\": \"{uniquePassword}\"}}";
        HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
        Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
        string loginResponseBody = await loginResponse.Content.ReadAsStringAsync();
        dynamic loginResponseMap = JsonConvert.DeserializeObject(loginResponseBody);
        string adminAuthToken = loginResponseMap.token;

        // Use the obtained token in the request to add a team
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", adminAuthToken);

        // Add a team
        var teamToAdd = new Team
        {
            TeamName = "Sample Team",
            teamDescription = "This is a sample team for testing purposes.",
            // You can add other properties based on your actual Team model
        };

        string teamRequestBody = JsonConvert.SerializeObject(teamToAdd);
        HttpResponseMessage teamResponse = await _httpClient.PostAsync("/api/team", new StringContent(teamRequestBody, Encoding.UTF8, "application/json"));

        // Check for successful status code
        Assert.AreEqual(HttpStatusCode.OK, teamResponse.StatusCode);

        // Check for valid response content
        string teamResponseBody = await teamResponse.Content.ReadAsStringAsync();
        dynamic teamResponseMap = JsonConvert.DeserializeObject(teamResponseBody);

        // Assuming the response contains a message indicating success
        Assert.AreEqual("Team added successfully", teamResponseMap.message.ToString());
    }
    catch (HttpRequestException httpEx)
    {
        // Log HTTP exception details
        Console.WriteLine($"HTTP Exception: {httpEx.Message}");
        if (httpEx.InnerException != null)
        {
            Console.WriteLine($"Inner Exception: {httpEx.InnerException.Message}");
        }

        // Re-throw the exception to mark the test as failed
        throw;
    }
    catch (Exception ex)
    {
        // Log general exception details
        Console.WriteLine($"Exception: {ex.Message}");
        Console.WriteLine($"StackTrace: {ex.StackTrace}");

        // Re-throw the exception to mark the test as failed
        throw;
    }
}

[Test]
public async Task Backend_TestGetAllTeams()
{
    try
    {
        // Generate unique identifiers
        string uniqueId = Guid.NewGuid().ToString();
        string uniqueUsername = $"abcd_{uniqueId}";
        string uniquePassword = $"abcdA{uniqueId}@123";
        string uniqueEmail = $"abcd{uniqueId}@gmail.com";

        // Register an admin user
        string registerRequestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"{uniquePassword}\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\",\"UserRole\" : \"Admin\" }}";
        HttpResponseMessage registerResponse = await _httpClient.PostAsync("/api/register", new StringContent(registerRequestBody, Encoding.UTF8, "application/json"));
        Assert.AreEqual(HttpStatusCode.OK, registerResponse.StatusCode);

        // Login the registered admin user
        string loginRequestBody = $"{{\"email\": \"{uniqueEmail}\",\"password\": \"{uniquePassword}\"}}";
        HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
        Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
        string loginResponseBody = await loginResponse.Content.ReadAsStringAsync();
        dynamic loginResponseMap = JsonConvert.DeserializeObject(loginResponseBody);
        string adminAuthToken = loginResponseMap.token;

        // Use the obtained token in the request to get all teams
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", adminAuthToken);

        // Get all teams
        HttpResponseMessage teamsResponse = await _httpClient.GetAsync("/api/team");
        
        // Check for successful status code
        Assert.AreEqual(HttpStatusCode.OK, teamsResponse.StatusCode);

        // Check for valid response content
        string teamsResponseBody = await teamsResponse.Content.ReadAsStringAsync();
        dynamic teamsResponseMap = JsonConvert.DeserializeObject(teamsResponseBody);

        // Assuming the response contains a list of teams
        Assert.IsNotNull(teamsResponseMap);
        Assert.IsInstanceOf<IEnumerable<dynamic>>(teamsResponseMap);
    }
    catch (HttpRequestException httpEx)
    {
        // Log HTTP exception details
        Console.WriteLine($"HTTP Exception: {httpEx.Message}");
        if (httpEx.InnerException != null)
        {
            Console.WriteLine($"Inner Exception: {httpEx.InnerException.Message}");
        }

        // Re-throw the exception to mark the test as failed
        throw;
    }
    catch (Exception ex)
    {
        // Log general exception details
        Console.WriteLine($"Exception: {ex.Message}");
        Console.WriteLine($"StackTrace: {ex.StackTrace}");

        // Re-throw the exception to mark the test as failed
        throw;
    }
}

[Test]
public async Task Backend_TestAddVenue()
{
    try
    {
        // Generate unique identifiers
        string uniqueId = Guid.NewGuid().ToString();
        string uniqueUsername = $"abcd_{uniqueId}";
        string uniquePassword = $"abcdA{uniqueId}@123";
        string uniqueEmail = $"abcd{uniqueId}@gmail.com";

        // Register an admin user
        string registerRequestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"{uniquePassword}\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\",\"UserRole\" : \"Admin\" }}";
        HttpResponseMessage registerResponse = await _httpClient.PostAsync("/api/register", new StringContent(registerRequestBody, Encoding.UTF8, "application/json"));
        Assert.AreEqual(HttpStatusCode.OK, registerResponse.StatusCode);

        // Login the registered admin user
        string loginRequestBody = $"{{\"email\": \"{uniqueEmail}\",\"password\": \"{uniquePassword}\"}}";
        HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
        Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
        string loginResponseBody = await loginResponse.Content.ReadAsStringAsync();
        dynamic loginResponseMap = JsonConvert.DeserializeObject(loginResponseBody);
        string adminAuthToken = loginResponseMap.token;

        // Use the obtained token in the request to add a venue
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", adminAuthToken);

        // Add a venue
        var venueToAdd = new Venue
        {
            VenueName = "Sample Venue",
            VenueLocation = "Sample Location",
            VenueImageURL = "https://example.com/image.jpg",
            VenueDescription = "This is a sample venue for testing purposes.",
            Schedules = new List<Schedule>(),  // Assuming an empty list for schedules
            // You can add other properties based on your actual Venue model
        };

        string venueRequestBody = JsonConvert.SerializeObject(venueToAdd);
        HttpResponseMessage venueResponse = await _httpClient.PostAsync("/api/venue", new StringContent(venueRequestBody, Encoding.UTF8, "application/json"));

        // Check for successful status code
        Assert.AreEqual(HttpStatusCode.OK, venueResponse.StatusCode);

        // Check for valid response content
        string venueResponseBody = await venueResponse.Content.ReadAsStringAsync();
        dynamic venueResponseMap = JsonConvert.DeserializeObject(venueResponseBody);

        // Assuming the response contains a message indicating success
        Assert.AreEqual("Venue added successfully", venueResponseMap.message.ToString());
    }
    catch (HttpRequestException httpEx)
    {
        // Log HTTP exception details
        Console.WriteLine($"HTTP Exception: {httpEx.Message}");
        if (httpEx.InnerException != null)
        {
            Console.WriteLine($"Inner Exception: {httpEx.InnerException.Message}");
        }

        // Re-throw the exception to mark the test as failed
        throw;
    }
    catch (Exception ex)
    {
        // Log general exception details
        Console.WriteLine($"Exception: {ex.Message}");
        Console.WriteLine($"StackTrace: {ex.StackTrace}");

        // Re-throw the exception to mark the test as failed
        throw;
    }
}


[Test]
public async Task Backend_TestGetAllVenues()
{
    try
    {
        // Generate unique identifiers
        string uniqueId = Guid.NewGuid().ToString();
        string uniqueUsername = $"abcd_{uniqueId}";
        string uniquePassword = $"abcdA{uniqueId}@123";
        string uniqueEmail = $"abcd{uniqueId}@gmail.com";

        // Register an admin user
        string registerRequestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"{uniquePassword}\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\",\"UserRole\" : \"Admin\" }}";
        HttpResponseMessage registerResponse = await _httpClient.PostAsync("/api/register", new StringContent(registerRequestBody, Encoding.UTF8, "application/json"));
        Assert.AreEqual(HttpStatusCode.OK, registerResponse.StatusCode);

        // Login the registered admin user
        string loginRequestBody = $"{{\"email\": \"{uniqueEmail}\",\"password\": \"{uniquePassword}\"}}";
        HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
        Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
        string loginResponseBody = await loginResponse.Content.ReadAsStringAsync();
        dynamic loginResponseMap = JsonConvert.DeserializeObject(loginResponseBody);
        string adminAuthToken = loginResponseMap.token;

        // Use the obtained token in the request to get all venues
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", adminAuthToken);

        // Get all venues
        HttpResponseMessage venuesResponse = await _httpClient.GetAsync("/api/venue");

        // Check for successful status code
        Assert.AreEqual(HttpStatusCode.OK, venuesResponse.StatusCode);

        // Check for valid response content
        string venuesResponseBody = await venuesResponse.Content.ReadAsStringAsync();
        dynamic venuesResponseMap = JsonConvert.DeserializeObject(venuesResponseBody);

        // Assuming the response contains a list of venues
        Assert.IsNotNull(venuesResponseMap);
        Assert.IsTrue(venuesResponseMap.Count > 0);  // Assuming at least one venue is returned
    }
    catch (HttpRequestException httpEx)
    {
        // Log HTTP exception details
        Console.WriteLine($"HTTP Exception: {httpEx.Message}");
        if (httpEx.InnerException != null)
        {
            Console.WriteLine($"Inner Exception: {httpEx.InnerException.Message}");
        }

        // Re-throw the exception to mark the test as failed
        throw;
    }
    catch (Exception ex)
    {
        // Log general exception details
        Console.WriteLine($"Exception: {ex.Message}");
        Console.WriteLine($"StackTrace: {ex.StackTrace}");

        // Re-throw the exception to mark the test as failed
        throw;
    }
}


}
