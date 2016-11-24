using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using KnockKnock.Web.Controllers;
using KnockKnock.Web.Interfaces;
using KnockKnock.Web.Services.Reverse;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace KnockKnock.Web.Tests.Controllers
{
    [TestClass]
    public class ReverseWordsControllerTests
    {
        [TestMethod]
        public async Task Get_ValidInput_OK()
        {
            // Arrange
            var controller = new ReverseWordsController(new ReverseWordsService())
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            var response = controller.Get("'Föobar Приве, однако мы стобой сказали: 'Хай хой'__ __ __'");
            var result = await response.ExecuteAsync(new CancellationToken());

            // Assert
            string resultValue;
            Assert.IsTrue(result.TryGetContentValue(out resultValue));
            Assert.AreEqual("'raboöF евирП, окандо ым йоботс илазакс: 'йаХ йох'__ __ __'", resultValue);
        }

        [TestMethod]
        public void Get_VeryLongString_BadRequest()
        {
            // Arrange
            var mockRepository = new Mock<IReverseWordsService>();

            mockRepository.Setup(x => x.ReverseWords("longString")).Throws(new MaxLengthException());
            var controller = new ReverseWordsController(mockRepository.Object);

            // Act
            IHttpActionResult actionResult = controller.Get("longString");

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestErrorMessageResult));
        }
    }
}