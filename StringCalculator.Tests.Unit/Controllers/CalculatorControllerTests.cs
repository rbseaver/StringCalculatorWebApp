using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StringCalculator.Api.Controllers;
using StringCalculator.Core.Interfaces;
using StringCalculator.Core.Models;
using StringCalculator.Core.Services;
using System.Threading.Tasks;

namespace StringCalculator.Tests.Unit.Controllers
{
    [TestClass]
    public class CalculatorControllerTests
    {
        [TestMethod]
        public void ShouldReturnZeroForEmptyString()
        {
            var controller = new CalculatorController(new CalculatorService());
            var numbers = new SumRequest { Numbers = string.Empty };
            var response = controller.Post(numbers);

            response.Result.Should().Be(0);
        }

        [TestMethod]
        public void ShouldReturnTheNumberPassedIn()
        {
            const string input = "1";
            const int expected = 1;
            var controller = new CalculatorController(new CalculatorService());
            var numbers = new SumRequest { Numbers = input };

            var response = controller.Post(numbers);

            response.Result.Should().Be(expected);
        }

        [TestMethod]
        [DataRow("1,1", 2)]
        [DataRow("1,3", 4)]
        [DataRow("2,6", 8)]
        [DataRow("2,6,3", 11)]
        [DataRow("3,6,9,12,15,18", 63)]
        public void ItShouldReturnSumOfNumbers(string input, int expected)
        {
            var controller = new CalculatorController(new CalculatorService());
            var numbers = new SumRequest { Numbers = input };

            var response = controller.Post(numbers);

            response.Result.Should().Be(expected);
        }

        [TestMethod]
        [DataRow("1\n1", 2)]
        [DataRow("1\n1,1", 3)]
        public void ItShouldAcceptNewlineDelimiter(string input, int expected)
        {
            var controller = new CalculatorController(new CalculatorService());
            var numbers = new SumRequest { Numbers = input };

            var response = controller.Post(numbers);

            response.Result.Should().Be(expected);
        }
    }
}