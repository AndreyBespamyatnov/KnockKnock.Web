using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using KnockKnock.Web.Controllers;
using KnockKnock.Web.Services.Reverse;
using KnockKnock.Web.Services.Triangle;
using KnockKnock.Web.Services.Triangle.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KnockKnock.Web.Tests.Controllers
{
    [TestClass]
    public class TriangleTypeControllerTests
    {
        [TestMethod]
        public async Task Get_ValidInput_OK()
        {
            // Arrange
            var controller = new TriangleTypeController(new TriangleService())
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            var response = controller.Get(0, 0, 0);
            var result = await response.ExecuteAsync(new CancellationToken());

            // Assert
            string resultValue;
            Assert.IsTrue(result.TryGetContentValue(out resultValue));
            Assert.AreEqual(TriangleType.Error.ToString(), resultValue);
        }
    }
}
