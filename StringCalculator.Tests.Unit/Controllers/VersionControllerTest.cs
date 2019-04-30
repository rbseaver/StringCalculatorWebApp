using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StringCalculator.Api;
using StringCalculator.Api.Controllers;
using StringCalculator.Core.Interfaces;
using System.Threading.Tasks;

namespace StringCalculator.Tests.Unit.Controllers
{
    [TestClass]
    public class VersionControllerTest
    {
        [TestMethod]
        public void ShouldReturnVersion()
        {
            var mockVersionService = new Mock<IVersionService>();
            var expectedVersion = typeof(Startup).Assembly.GetName().Version.ToString();
            mockVersionService.Setup(x => x.GetVersionAsync<Startup>())
                .Returns(Task.FromResult(expectedVersion));
            var controller = new VersionController(mockVersionService.Object);

            var version = controller.Get().Result;

            version.Should().Be(expectedVersion);
        }
    }
}