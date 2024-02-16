using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


[TestFixture]
public class Tests
{
    private HttpClient _httpClient;
    private string _generatedToken;
    [SetUp]
    public void Setup()
    {
         _httpClient = new HttpClient();
        // _httpClient.BaseAddress = new Uri("https://localhost:7266"); 
        // _httpClient.BaseAddress = new Uri("https://api.example.com/"); 
        _httpClient.BaseAddress = new Uri("https://8080-bfdeeddcedfabcfacbdcbaeadbebabcdebdca.premiumproject.examly.io/"); 


    }

    // [Test]
    // public void Test1()
    // {
    //     Assert.Pass();
    // }

    // [Test, Order(1)]
    // public async Task Backend_TestRegisterUser()
    // {
    //     string uniqueId = Guid.NewGuid().ToString();

    //     // Generate a unique userName based on a timestamp
    //     string uniqueUsername = $"abcd_{uniqueId}";
    //     string uniqueEmail = $"abcd{uniqueId}@gmail.com";


    //     string requestBody = $"{{\"password\": \"abc@123A\",\"email\": \"{uniqueEmail}\"}}";
    //     HttpResponseMessage response = await _httpClient.PostAsync("/api/login", new StringContent(requestBody, Encoding.UTF8, "application/json"));
    //     Console.WriteLine(response.Content);
    //     string responseString = await response.Content.ReadAsStringAsync();

    //     Console.WriteLine(response.StatusCode);
    //     Console.WriteLine(responseString);
    //     // Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    // }

    [Test, Order(1)]
    public async Task Backend_TestLoginAdmin()
    {
        string uniqueId = Guid.NewGuid().ToString();

        string uniqueusername = $"abcd_{uniqueId}";
        string uniquepassword = $"abcdA{uniqueId}@123";
        string uniquerole = "admin";
        string requestBody = $"{{\"Username\" : \"{uniqueusername}\",\"Password\" : \"{uniquepassword}\",\"Role\" : \"{uniquerole}\" }}";
        HttpResponseMessage response = await _httpClient.PostAsync("/api/register", new StringContent(requestBody, Encoding.UTF8, "application/json"));
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        string requestBody1 = $"{{\"Username\" : \"{uniqueemail}\",\"Password\" : \"{uniquepassword}\"}}";
        HttpResponseMessage response1 = await _httpClient.PostAsync("/api/login", new StringContent(requestBody1, Encoding.UTF8, "application/json"));
        Assert.AreEqual(HttpStatusCode.OK, response1.StatusCode);
        string responseBody = await response1.Content.ReadAsStringAsync();
    }

    [TearDown]
    public void TearDown()
    {
        // Cleanup or additional teardown logic if needed.
        _httpClient.Dispose();
    }
}