using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator.Core.Services;
using System.Threading.Tasks;

namespace StringCalculator.Tests.Unit.Services
{
    [TestClass]
    public class CalculatorServiceTests
    {
        [TestMethod]
        public async Task ItShouldReturnZeroForEmptyString()
        {
            var service = new CalculatorService();

            int result = await service.Add(string.Empty);

            result.Should().Be(0);
        }

        [TestMethod]
        public async Task ItShouldReturnTheNumberPassedIn()
        {
            var service = new CalculatorService();

            int result = await service.Add("1");

            result.Should().Be(1);
        }
    }
}