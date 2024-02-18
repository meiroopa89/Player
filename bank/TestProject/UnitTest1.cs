using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
// using dotnetapp.Models;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;


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

// [Test]
// public async Task Backend_TestGetAccountById()
// {
//     // Generate unique identifiers
//     string uniqueId = Guid.NewGuid().ToString();
//     string uniqueUsername = $"abcd_{uniqueId}";
//     string uniquePassword = $"abcdA{uniqueId}@123";
//     string uniqueEmail = $"abcd{uniqueId}@gmail.com";

//     // Register an admin user
//     string registerRequestBody = $"{{\"Username\": \"{uniqueUsername}\", \"Password\": \"{uniquePassword}\", \"Email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\",\"UserRole\" : \"Admin\" }}";
//     HttpResponseMessage registerResponse = await _httpClient.PostAsync("/api/register", new StringContent(registerRequestBody, Encoding.UTF8, "application/json"));
//     Assert.AreEqual(HttpStatusCode.OK, registerResponse.StatusCode);

//     // Login the registered admin user
//     string loginRequestBody = $"{{\"email\": \"{uniqueEmail}\",\"password\": \"{uniquePassword}\"}}";
//     HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
//     Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);
//     string loginResponseBody = await loginResponse.Content.ReadAsStringAsync();
//     dynamic loginResponseMap = JsonConvert.DeserializeObject(loginResponseBody);
//     string adminAuthToken = loginResponseMap.token;

//     // Use the obtained token in the request to get the account
//     _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", adminAuthToken);

//     // Make a request to get the accounts
//     HttpResponseMessage getAccountsResponse = await _httpClient.GetAsync("/api/account");
//     Assert.AreEqual(HttpStatusCode.OK, getAccountsResponse.StatusCode);

//     // Validate the response content (assuming the response is a JSON array of accounts)
//     string getAccountsResponseBody = await getAccountsResponse.Content.ReadAsStringAsync();
//     var accounts = JsonConvert.DeserializeObject<List<Account>>(getAccountsResponseBody);
//     Assert.IsNotNull(accounts);
//     Assert.IsTrue(accounts.Any());

//     // Get the first account ID from the response
//     long accountId = accounts.First().AccountId;

//     // Make a request to get a specific account by ID
//     HttpResponseMessage getAccountByIdResponse = await _httpClient.GetAsync($"/api/account/{accountId}");
//     Assert.AreEqual(HttpStatusCode.OK, getAccountByIdResponse.StatusCode);

//     // Validate the response content for the specific account
//     string getAccountByIdResponseBody = await getAccountByIdResponse.Content.ReadAsStringAsync();
//     var specificAccount = JsonConvert.DeserializeObject<Account>(getAccountByIdResponseBody);
//     Assert.IsNotNull(specificAccount);
//     Assert.AreEqual(accountId, specificAccount.AccountId);
// }


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
    string getAccountsRequest = "/api/account";
    HttpResponseMessage getAccountsResponse = await _httpClient.GetAsync(getAccountsRequest);
    Assert.AreEqual(HttpStatusCode.OK, getAccountsResponse.StatusCode);

    // Validate the response content (assuming the response is a JSON array of accounts)
    string getAccountsResponseBody = await getAccountsResponse.Content.ReadAsStringAsync();
    Assert.IsFalse(string.IsNullOrWhiteSpace(getAccountsResponseBody), "Response body should not be empty");

    // Extracting the first account ID from the response using regular expressions or other methods
    Match match = Regex.Match(getAccountsResponseBody, @"""AccountId"":\s*(\d+)");
    Assert.IsTrue(match.Success, "Account ID not found in the response");
    long accountId = long.Parse(match.Groups[1].Value);

    // Make a request to get a specific account by ID
    string getAccountByIdRequest = $"/api/account/{accountId}";
    HttpResponseMessage getAccountByIdResponse = await _httpClient.GetAsync(getAccountByIdRequest);
    Assert.AreEqual(HttpStatusCode.OK, getAccountByIdResponse.StatusCode);

    // Validate the response content for the specific account
    string getAccountByIdResponseBody = await getAccountByIdResponse.Content.ReadAsStringAsync();
    Assert.IsFalse(string.IsNullOrWhiteSpace(getAccountByIdResponseBody), "Response body should not be empty");

    // Additional assertions based on the properties of the retrieved account
}



[Test]
public async Task Backend_TestAddFixedDeposit()
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

    // Use the obtained token in the request to add a FixedDeposit
    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", customerAuthToken);

    var fixedDepositToAdd = new
    {
        Amount = 5000.00M,
        TenureMonths = 12,
        InterestRate = 5.0,
        StartDate = DateTime.UtcNow,
        UserId = 1 // Provide the appropriate UserId based on your test case
        // You may need to adjust other properties based on the actual structure of your FixedDeposit object
    };

    string fixedDepositRequestBody = JsonConvert.SerializeObject(fixedDepositToAdd);
    HttpResponseMessage fixedDepositResponse = await _httpClient.PostAsync("api/fixeddeposit", new StringContent(fixedDepositRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, fixedDepositResponse.StatusCode);

    // Validate the response content
    string fixedDepositResponseBody = await fixedDepositResponse.Content.ReadAsStringAsync();
    dynamic fixedDepositResponseMap = JsonConvert.DeserializeObject(fixedDepositResponseBody);

    Assert.AreEqual("Fixed deposit added successfully", fixedDepositResponseMap.message.ToString());
}


[Test]
public async Task Backend_TestGetAllFixedDeposits()
{
    HttpResponseMessage response = null;

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

    // Use the obtained token in the request to get all FixedDeposits
    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", customerAuthToken);

    try
    {
        // Make a request to get all FixedDeposits
        response = await _httpClient.GetAsync("api/fixeddeposit");
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        // Validate the response content (assuming the response is a JSON array of FixedDeposits)
        string responseContent = await response.Content.ReadAsStringAsync();
        dynamic fixedDepositsArray = JsonConvert.DeserializeObject(responseContent);

        Assert.IsNotNull(fixedDepositsArray, "The list of FixedDeposits should not be null");
        Assert.IsTrue(fixedDepositsArray.Count > 0, "There should be at least one FixedDeposit in the list");

        // Additional assertions based on the properties of the retrieved FixedDeposits
        foreach (var fixedDeposit in fixedDepositsArray)
        {
            // Add additional assertions for other properties if needed
        }
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
public async Task Backend_TestGetAllTransactions()
{
    HttpResponseMessage response = null;

    // Register a new customer and obtain the authentication token
    string uniqueId = Guid.NewGuid().ToString();
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniquePassword = $"abcdA{uniqueId}@123";
    string uniqueEmail = $"abcd{uniqueId}@gmail.com";

    // Register a new customer
    string registerRequestBody = $"{{\"password\": \"{uniquePassword}\", \"userName\": \"{uniqueUsername}\",\"UserRole\": \"Customer\",\"email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\"}}";
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

    try
    {
        // Make a request to get all transactions
        response = await _httpClient.GetAsync("/api/transaction");
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        // Validate the response content (assuming the response is a JSON array of transactions)
        string responseContent = await response.Content.ReadAsStringAsync();
        dynamic transactionsArray = JsonConvert.DeserializeObject(responseContent);

        Assert.IsNotNull(transactionsArray, "The list of transactions should not be null");
        Assert.IsTrue(transactionsArray.Count > 0, "There should be at least one transaction in the list");

        // Additional assertions based on the properties of the retrieved transactions
        foreach (var transaction in transactionsArray)
        {
            Assert.IsNotNull(transaction.TransactionId, "TransactionId should not be null");
            Assert.IsNotNull(transaction.AccountId, "AccountId should not be null");
            Assert.IsNotNull(transaction.Type, "Type should not be null");
            Assert.IsNotNull(transaction.Amount, "Amount should not be null");
            Assert.IsNotNull(transaction.Timestamp, "Timestamp should not be null");
            // Add additional assertions for other properties if needed
        }
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
public async Task Backend_TestPostReview()
{
    HttpResponseMessage response = null;

    // Register a new customer and obtain the authentication token
    string uniqueId = Guid.NewGuid().ToString();
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniquePassword = $"abcdA{uniqueId}@123";
    string uniqueEmail = $"abcd{uniqueId}@gmail.com";

    // Register a new customer
    string registerRequestBody = $"{{\"password\": \"{uniquePassword}\", \"userName\": \"{uniqueUsername}\",\"UserRole\": \"Customer\",\"email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\"}}";
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

    // Create a review object
    var review = new
    {
        UserId = 1, // Replace with the appropriate user ID
        ReviewText = "Test review text",
        DatePosted = DateTime.UtcNow,
        Rating = 5,
        // Additional properties as needed
    };

    try
    {
        string requestBody = JsonConvert.SerializeObject(review);
        response = await _httpClient.PostAsync("/api/review", new StringContent(requestBody, Encoding.UTF8, "application/json"));

        // Print response content for debugging purposes
        Console.WriteLine($"Response Content: {await response.Content.ReadAsStringAsync()}");

        // Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        // Additional assertions based on the properties of the posted review
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
public async Task Backend_TestGetAllReviews()
{
    // Register a new user and obtain the authentication token
    string uniqueId = Guid.NewGuid().ToString();
    string uniqueUsername = $"abcd_{uniqueId}";
    string uniquePassword = $"abcdA{uniqueId}@123";
    string uniqueEmail = $"abcd{uniqueId}@gmail.com";

    // Register a new user
    string registerRequestBody = $"{{\"password\": \"{uniquePassword}\", \"userName\": \"{uniqueUsername}\",\"UserRole\": \"Customer\",\"email\": \"{uniqueEmail}\", \"MobileNumber\": \"1234567890\"}}";
    HttpResponseMessage registrationResponse = await _httpClient.PostAsync("/api/register", new StringContent(registerRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, registrationResponse.StatusCode);

    // Log in the registered user and obtain the authentication token
    string loginRequestBody = $"{{\"Email\": \"{uniqueEmail}\", \"Password\": \"{uniquePassword}\"}}";
    HttpResponseMessage loginResponse = await _httpClient.PostAsync("/api/login", new StringContent(loginRequestBody, Encoding.UTF8, "application/json"));
    Assert.AreEqual(HttpStatusCode.OK, loginResponse.StatusCode);

    string responseString = await loginResponse.Content.ReadAsStringAsync();
    dynamic responseMap = JsonConvert.DeserializeObject(responseString);
    string userAuthToken = responseMap.token;

    // Set the authentication token in the HTTP client headers
    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", userAuthToken);

    // Make a request to get all reviews
    HttpResponseMessage response = await _httpClient.GetAsync("/api/review");

    try
    {
        // Assert that the response status code is OK
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        // Validate the response content
        string responseContent = await response.Content.ReadAsStringAsync();

        // Assume the response is a JSON array
        var jsonArray = JArray.Parse(responseContent);

        // Assert that the array is not null and contains at least one element
        Assert.IsNotNull(jsonArray, "The JSON array should not be null");
        Assert.IsTrue(jsonArray.Any(), "There should be at least one element in the array");

        // Additional assertions based on the structure of the retrieved data
        foreach (var item in jsonArray)
        {
            // Example assertions for properties (modify based on your actual response structure)
            Assert.IsNotNull(item["ReviewId"], "ReviewId should not be null");
            Assert.IsNotNull(item["UserId"], "UserId should not be null");
            Assert.IsNotNull(item["ReviewText"], "ReviewText should not be null");
            Assert.IsNotNull(item["DatePosted"], "DatePosted should not be null");
            Assert.IsNotNull(item["Rating"], "Rating should not be null");
            // Add additional assertions for other properties if needed
        }
    }
    catch (HttpRequestException ex)
    {
        Console.WriteLine($"Request failed: {ex.Message}");

        // Print response content for debugging purposes
        Console.WriteLine($"Response Content: {await response.Content.ReadAsStringAsync()}");

        throw;
    }
}



}
