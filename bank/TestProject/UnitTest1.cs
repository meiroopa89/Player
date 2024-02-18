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

        string requestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"abc@123A\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\", \"UserRole\": \"Customer\"}}";
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
        string uniqueuserrole = "Customer";
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
public async Task Backend_TestAddAccount()
{
    try
    {
        // Generate unique identifiers
        string uniqueId = Guid.NewGuid().ToString();
        string uniqueUsername = $"abcd_{uniqueId}";
        string uniquePassword = $"abcdA{uniqueId}@123";
        string uniqueEmail = $"abcd{uniqueId}@gmail.com";

        // Register a customer
        string registerRequestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"{uniquePassword}\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\",\"UserRole\" : \"Customer\" }}";
        HttpResponseMessage registerResponse = await _httpClient.PostAsync("/api/register", new StringContent(registerRequestBody, Encoding.UTF8, "application/json"));
        Assert.AreEqual(HttpStatusCode.OK, registerResponse.StatusCode);

        // Login the registered customer
        string loginRequestBody = $"{{\"email\": \"{uniqueEmail}\",\"password\": \"{uniquePassword}\"}}";
        HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
        Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
        string loginResponseBody = await loginResponse.Content.ReadAsStringAsync();
        dynamic loginResponseMap = JsonConvert.DeserializeObject(loginResponseBody);
        string customerAuthToken = loginResponseMap.token;

        // Use the obtained token in the request to add an account
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", customerAuthToken);

        var accountToAdd = new
        {
            // Include properties based on your actual Account model
            UserId = 1, // Use the UserId of the registered customer
            Balance = 1000.00,
            AccountType = "Savings"
        };

        string accountRequestBody = JsonConvert.SerializeObject(accountToAdd);
        HttpResponseMessage accountResponse = await _httpClient.PostAsync("/api/account", new StringContent(accountRequestBody, Encoding.UTF8, "application/json"));
        
        // Check for successful status code
        Assert.AreEqual(HttpStatusCode.OK, accountResponse.StatusCode);

        // Check for valid response content
        string accountResponseBody = await accountResponse.Content.ReadAsStringAsync();
        dynamic accountResponseMap = JsonConvert.DeserializeObject(accountResponseBody);

        // Assuming the response contains a message indicating success
        Assert.AreEqual("Account added successfully", accountResponseMap.message.ToString());
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
public async Task Backend_TestGetAllAccounts()
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

        // Use the obtained token in the request to get all accounts
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", adminAuthToken);

        HttpResponseMessage accountsResponse = await _httpClient.GetAsync("/api/account");
        
        // Check for successful status code
        Assert.AreEqual(HttpStatusCode.OK, accountsResponse.StatusCode);

        // Check for valid response content
        string accountsResponseBody = await accountsResponse.Content.ReadAsStringAsync();
        dynamic accountsResponseMap = JsonConvert.DeserializeObject(accountsResponseBody);

        // Assuming the response contains a list of accounts
        Assert.IsNotNull(accountsResponseMap);
        Assert.IsTrue(accountsResponseMap.Count > 0);
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
public async Task Backend_TestGetAccountById()
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

    // Use the obtained token in the request to get the account
    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", adminAuthToken);

    // Make a request to get the accounts
    HttpResponseMessage getAccountsResponse = await _httpClient.GetAsync("/api/account");
    Assert.AreEqual(HttpStatusCode.OK, getAccountsResponse.StatusCode);

    // Validate the response content (assuming the response is a JSON array of accounts)
    string getAccountsResponseBody = await getAccountsResponse.Content.ReadAsStringAsync();
    var accounts = JsonConvert.DeserializeObject<List<Account>>(getAccountsResponseBody);
    Assert.IsNotNull(accounts);
    Assert.IsTrue(accounts.Any());

    // Get the first account ID from the response
    long accountId = accounts.First().AccountId;

    // Make a request to get a specific account by ID
    HttpResponseMessage getAccountByIdResponse = await _httpClient.GetAsync($"/api/account/{accountId}");
    Assert.AreEqual(HttpStatusCode.OK, getAccountByIdResponse.StatusCode);

    // Validate the response content for the specific account
    string getAccountByIdResponseBody = await getAccountByIdResponse.Content.ReadAsStringAsync();
    var specificAccount = JsonConvert.DeserializeObject<Account>(getAccountByIdResponseBody);
    Assert.IsNotNull(specificAccount);
    Assert.AreEqual(accountId, specificAccount.AccountId);
}


// [Test]
// public async Task Backend_TestUpdateAccount()
// {
//     // Generate unique identifiers
//     string uniqueId = Guid.NewGuid().ToString();
//     string uniqueUsername = $"abcd_{uniqueId}";
//     string uniquePassword = $"abcdA{uniqueId}@123";
//     string uniqueEmail = $"abcd{uniqueId}@gmail.com";

//     // Register a customer
//     string registerRequestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"{uniquePassword}\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\",\"UserRole\" : \"Customer\" }}";
//     HttpResponseMessage registerResponse = await _httpClient.PostAsync("/api/register", new StringContent(registerRequestBody, Encoding.UTF8, "application/json"));
//     Assert.AreEqual(HttpStatusCode.OK, registerResponse.StatusCode);

//     // Login the registered customer
//     string loginRequestBody = $"{{\"email\": \"{uniqueEmail}\",\"password\": \"{uniquePassword}\"}}";
//     HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
//     Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
//     string loginResponseBody = await loginResponse.Content.ReadAsStringAsync();
//     dynamic loginResponseMap = JsonConvert.DeserializeObject(loginResponseBody);
//     string customerAuthToken = loginResponseMap.token;

//     // Use the obtained token in the request to get the customer's accounts
//     _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", customerAuthToken);

//     // Make a request to get the customer's accounts
//     HttpResponseMessage getAccountsResponse = await _httpClient.GetAsync("/api/account");
//     Assert.AreEqual(HttpStatusCode.OK, getAccountsResponse.StatusCode);

//     // Validate the response content (assuming the response is a JSON array of accounts)
//     string getAccountsResponseBody = await getAccountsResponse.Content.ReadAsStringAsync();
//     var accounts = JsonConvert.DeserializeObject<List<Account>>(getAccountsResponseBody);
//     Assert.IsNotNull(accounts);
//     Assert.IsTrue(accounts.Any());

//     // Get the first account ID from the response
//     long accountId = accounts.First().AccountId;

//     // Generate updated account data
//     var updatedAccount = new Account
//     {
//         Balance = 1000.0m, // Update balance as needed
//         AccountType = "Savings", // Update account type as needed
//         // Add more properties as needed
//     };

//     // Make a request to update the account
//     string updateAccountRequestBody = JsonConvert.SerializeObject(updatedAccount);
//     HttpResponseMessage updateAccountResponse = await _httpClient.PutAsync($"/api/account/{accountId}", new StringContent(updateAccountRequestBody, Encoding.UTF8, "application/json"));
//     Assert.AreEqual(HttpStatusCode.OK, updateAccountResponse.StatusCode);

//     // Validate the response content
//     string updateAccountResponseBody = await updateAccountResponse.Content.ReadAsStringAsync();
//     dynamic updateAccountResponseMap = JsonConvert.DeserializeObject(updateAccountResponseBody);

//     // Corrected assertion for the response message
//     Assert.AreEqual("Account updated successfully", updateAccountResponseMap.message.ToString());
// }


// [Test]
// public async Task Backend_TestAddFDRequest()
// {
//     // Generate unique identifiers
//     string uniqueId = Guid.NewGuid().ToString();
//     string uniqueUsername = $"abcd_{uniqueId}";
//     string uniquePassword = $"abcdA{uniqueId}@123";
//     string uniqueEmail = $"abcd{uniqueId}@gmail.com";

//     // Register a customer
//     string registerRequestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"{uniquePassword}\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\",\"UserRole\" : \"Customer\" }}";
//     HttpResponseMessage registerResponse = await _httpClient.PostAsync("/api/register", new StringContent(registerRequestBody, Encoding.UTF8, "application/json"));
//     Assert.AreEqual(HttpStatusCode.OK, registerResponse.StatusCode);

//     // Login the registered customer
//     string loginRequestBody = $"{{\"email\": \"{uniqueEmail}\",\"password\": \"{uniquePassword}\"}}";
//     HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
//     Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
//     string loginResponseBody = await loginResponse.Content.ReadAsStringAsync();
//     dynamic loginResponseMap = JsonConvert.DeserializeObject(loginResponseBody);
//     string customerAuthToken = loginResponseMap.token;

//     // Use the obtained token in the request to add an FDRequest
//     _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", customerAuthToken);

//     var fdRequestToAdd = new
//     {
//         FDRequestId = 0, // This value will be replaced with the actual ID assigned by the server
//         FixedDepositId = 0, // Provide the appropriate FixedDepositId
//         Status = "Pending",
//         // Additional properties as needed
//         // ...
//     };

//     string fdRequestRequestBody = JsonConvert.SerializeObject(fdRequestToAdd);
//     HttpResponseMessage fdRequestResponse = await _httpClient.PostAsync("api/fdrequest", new StringContent(fdRequestRequestBody, Encoding.UTF8, "application/json"));
//     Assert.AreEqual(HttpStatusCode.OK, fdRequestResponse.StatusCode);

//     // Validate the response content
//     string fdRequestResponseBody = await fdRequestResponse.Content.ReadAsStringAsync();
//     dynamic fdRequestResponseMap = JsonConvert.DeserializeObject(fdRequestResponseBody);

//     Assert.AreEqual("FDRequest added successfully", fdRequestResponseMap.message.ToString());
// }


}
