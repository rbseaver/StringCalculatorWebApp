using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StringCalculator.Api;
using StringCalculator.Core.Interfaces;
using StringCalculator.Core.Services;
using System.Threading.Tasks;

namespace StringCalculator.Tests.Unit.Services
{
    [TestClass]
    public class VersionServiceTests
    {
        [TestMethod]
        public async Task ShouldReturnVersion()
        {
            var assemblyProvider = new Mock<IAssemblyProvider>();
            assemblyProvider.Setup(x => x.GetAssemblyVersion<Startup>())
                .Returns(typeof(Startup).Assembly.GetName().Version.ToString());

            var service = new VersionService(assemblyProvider.Object);

            var version = await service.GetVersionAsync<Startup>();

            version.Should().Be(typeof(Startup).Assembly.GetName().Version.ToString());
        }
    }
}