using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator.Api;
using System.Net.Http;
using System.Threading.Tasks;

namespace StringCalculator.Tests.Integration.Controllers
{
    [TestClass]
    public class VersionControllerTest
    {
        private TestServer server;
        private HttpClient client;

        [TestInitialize]
        public void Setup()
        {
            var webhostBuilder = new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>();

            server = new TestServer(webhostBuilder);

            client = server.CreateClient();
        }

        [TestMethod]
        public async Task ShouldReturnVersion()
        {
            var response = await client.GetAsync("/api/version");

            response.EnsureSuccessStatusCode();

            var version = await response.Content.ReadAsStringAsync();

            Assert.AreEqual("1.0.0.0", version);
        }
    }
}