using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StringCalculator.Api.Controllers;
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
            var calculatorService = new Mock<ICalculatorService>();
            calculatorService.Setup(x => x.Add(string.Empty)).Returns(Task.FromResult(0));
            var controller = new CalculatorController(calculatorService.Object);

            var response = controller.Post(string.Empty);

            response.Result.Should().Be(0);
        }
    }
}