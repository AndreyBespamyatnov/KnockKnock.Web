using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using KnockKnock.Web.Controllers;
using KnockKnock.Web.Interfaces;
using KnockKnock.Web.Services.Fibanacci;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace KnockKnock.Web.Tests.Controllers
{
    [TestClass]
    public class FibonacciControllerTests
    {
        [TestMethod]
        public async Task Get_ValidInput_OK()
        {
            // Arrange
            var controller = new FibonacciController(new FibonachiService())
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            var response = controller.Get(9);
            var result = await response.ExecuteAsync(new CancellationToken());

            // Assert
            long resultValue;
            Assert.IsTrue(result.TryGetContentValue(out resultValue));
            Assert.AreEqual(34, resultValue);
        }

        [TestMethod]
        public void Get_Exception_BadRequest()
        {
            // Arrange
            var mockRepository = new Mock<IFibonachiService>();

            mockRepository.Setup(x => x.GetNumber(9)).Throws(new Exception());
            var controller = new FibonacciController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.Get(9);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestErrorMessageResult));
        }
    }
}
