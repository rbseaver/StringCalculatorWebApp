using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Tests.Integration.Controllers
{
    [TestClass]
    public class CalculatorControllerTests
    {
        [TestMethod]
        public async Task ItShouldReturnZeroForEmptyString()
        {
            using (var client = TestClient.CreateClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(string.Empty), Encoding.UTF8, "application/json");

                using (var response = await client.PostAsync("/api/calculator", content))
                {
                    response.EnsureSuccessStatusCode();
                    var result = await response.Content.ReadAsAsync<int>();
                    result.Should().Be(0);
                }
            }
        }

        [TestMethod]
        public async Task ItShouldReturnTheNumberPassedIn()
        {
            using (var client = TestClient.CreateClient())
            {
                var content = new StringContent("1", Encoding.UTF8, "application/json");

                using (var response = await client.PostAsync("/api/calculator", content))
                {
                    response.EnsureSuccessStatusCode();
                    var result = await response.Content.ReadAsAsync<int>();
                    result.Should().Be(1);
                }
            }

        }
    }
}