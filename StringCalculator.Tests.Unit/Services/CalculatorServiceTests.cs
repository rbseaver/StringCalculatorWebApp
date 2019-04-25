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

            var result = await service.Add(string.Empty);

            result.Should().Be(0);
        }

        [TestMethod]
        public async Task ItShouldReturnTheNumberPassedIn()
        {
            var service = new CalculatorService();

            var result = await service.Add("1");

            result.Should().Be(1);
        }

        [TestMethod]
        [DataRow("1,1", 2)]
        [DataRow("1,3", 4)]
        [DataRow("2,6", 8)]
        [DataRow("2,6,3", 11)]
        [DataRow("3,6,9,12,15,18", 63)]
        public async Task ItShouldReturnSumOfNumbers(string input, int expected)
        {
            var service = new CalculatorService();

            var result = await service.Add(input);

            result.Should().Be(expected);
        }
    }
}