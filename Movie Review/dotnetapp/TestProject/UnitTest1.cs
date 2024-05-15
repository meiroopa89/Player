using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using dotnetapp.Models;
using Microsoft.AspNetCore.Hosting;

namespace dotnetapp.Tests
{
    [TestFixture]
    public class ReviewControllerTests
    {
        private WebApplicationFactory<Startup> _factory;
        private HttpClient _client;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _factory = new WebApplicationFactory<Startup>();
            _client = _factory.CreateClient();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _client.Dispose();
            _factory.Dispose();
        }

        [Test]
        public async Task GetReviews_ReturnsOkResult()
        {
            // Arrange
            var response = await _client.GetAsync("/api/review");

            // Act
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public async Task AddReview_ReturnsOkResult()
        {
            // Arrange
            var review = new Review { /* initialize properties */ };
            var json = JsonConvert.SerializeObject(review);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/review", content);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public async Task DeleteReview_ReturnsOkResult()
        {
            // Arrange
            var review = new Review { /* initialize properties */ };
            _client.PostAsync("/api/review", new StringContent(JsonConvert.SerializeObject(review), Encoding.UTF8, "application/json"));

            // Get the review ID from the response or database
            var reviewId = /* get the review ID */;

            // Act
            var response = await _client.DeleteAsync($"/api/review/{reviewId}");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
        }
    }
}
