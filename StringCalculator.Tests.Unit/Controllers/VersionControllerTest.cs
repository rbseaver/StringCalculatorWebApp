using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StringCalculator.Api.Controllers;
using StringCalculator.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
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
            mockVersionService.Setup(x => x.GetVersion()).Returns(Task.FromResult("1.0.0.0"));
            var controller = new VersionController(mockVersionService.Object);

            var version = controller.Get().Result;

            version.Should().Be("1.0.0.0");
        }
    }
}