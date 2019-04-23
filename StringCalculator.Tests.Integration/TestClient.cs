using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using StringCalculator.Api;
using System.Net.Http;

namespace StringCalculator.Tests.Integration
{
    public static class TestClient
    {
        private static TestServer server;
        private static HttpClient client;

        public static HttpClient CreateClient()
        {
            var webhostBuilder = new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>();

            server = new TestServer(webhostBuilder);

            client = server.CreateClient();

            return client;
        }
    }
}