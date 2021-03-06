﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator.Api;
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

            using (var response = await client.GetAsync("/api/version"))
            {
                response.EnsureSuccessStatusCode();
                var version = await response.Content.ReadAsStringAsync();
                Assert.AreEqual(typeof(Startup).Assembly.GetName().Version.ToString(), version);
            }
        }
    }
}