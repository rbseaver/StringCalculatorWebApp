using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var service = new VersionService();

            var version = await service.GetVersion();

            version.Should().Be("1.0.0.0");
        }
    }
}