using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace StringCalculator.Tests.Integration.Controllers
{
    [TestClass]
    public class VersionControllerTest
    {
        [TestMethod]
        public async Task ShouldReturnVersion()
        {
            var client = TestClient.CreateClient();

            var response = await client.GetAsync("/api/version");

            response.EnsureSuccessStatusCode();

            var version = await response.Content.ReadAsStringAsync();

            Assert.AreEqual("1.0.0.0", version);
        }
    }
}