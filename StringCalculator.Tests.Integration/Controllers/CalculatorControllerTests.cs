using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using StringCalculator.Core.Models;
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
                var numbers = new SumRequest { Numbers = string.Empty };
                var content = new StringContent(JsonConvert.SerializeObject(numbers), Encoding.UTF8, "application/json");

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
                var numbers = new SumRequest { Numbers = "1" };
                var content = new StringContent(JsonConvert.SerializeObject(numbers), Encoding.UTF8, "application/json");

                using (var response = await client.PostAsync("/api/calculator", content))
                {
                    response.EnsureSuccessStatusCode();
                    var result = await response.Content.ReadAsAsync<int>();
                    result.Should().Be(1);
                }
            }
        }

        [TestMethod]
        [DataRow("1,1", 2)]
        [DataRow("1,3", 4)]
        [DataRow("2,6", 8)]
        [DataRow("2,6,3", 11)]
        [DataRow("3,6,9,12,15,18", 63)]
        [DataRow("1\n1", 2)]
        [DataRow("1\n1,3", 5)]
        public async Task ItShouldReturnSumOfNumbers(string input, int expected)
        {
            using (var client = TestClient.CreateClient())
            {
                var numbers = new SumRequest { Numbers = input };
                var content = new StringContent(JsonConvert.SerializeObject(numbers), Encoding.UTF8, "application/json");

                using (var response = await client.PostAsync("/api/calculator", content))
                {
                    response.EnsureSuccessStatusCode();
                    var result = await response.Content.ReadAsAsync<int>();
                    result.Should().Be(expected);
                }
            }
        }
    }
}