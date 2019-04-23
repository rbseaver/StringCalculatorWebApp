using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;

namespace StringCalculator.Tests.Integration.Controllers
{
    [TestClass]
    public class CalculatorControllerTests
    {
        [TestMethod]
        public async Task ItShouldReturnZeroForEmptyString()
        {
            var client = TestClient.CreateClient();

            var content = new StringContent(string.Empty);

            var response = await client.PostAsync("/api/calculator", content);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<int>();

            Assert.AreEqual(0, result);
        }
    }
}