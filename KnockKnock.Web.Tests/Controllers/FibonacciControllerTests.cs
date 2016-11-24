using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using KnockKnock.Web.Controllers;
using KnockKnock.Web.Services.Fibanacci;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
