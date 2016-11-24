using System;
using KnockKnock.Web.Services.Reverse;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KnockKnock.Web.Tests.Services
{
    [TestClass]
    public class ReverseWordsServiceTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var inputStr = "'Oh, you can't help that,' said the Cat: 'we're all mad here. I'm mad. You're mad.'";

            var doWork = new ReverseWordsService().ReverseWords(inputStr);

            Assert.AreEqual(doWork, "'hO, uoy nac't pleh taht,' dias eht taC: 'ew'er lla dam ereh. I'm dam. uoY'er dam.'");
        }

        [TestMethod]
        public void TestMethod1_2()
        {
            var inputStr = "'Föobar Приве, однако мы стобой сказали: 'Хай хой'__ __ __'";

            var doWork = new ReverseWordsService().ReverseWords(inputStr);

            Assert.AreEqual(doWork, "'raboöF евирП, окандо ым йоботс илазакс: 'йаХ йох'__ __ __'");
        }

        [TestMethod]
        public void TestMethod3()
        {
            var reverseService = new ReverseWordsService();

            var inputStr = new string(new char[int.MaxValue / 21]);

            Exception exception = null;
            try
            {
                reverseService.ReverseWords(inputStr);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is MaxLengthException);
                exception = ex;
            }
            Assert.IsNotNull(exception);
        }

        [TestMethod]
        public void TestMethod1_4()
        {
            var inputStr = "You're new here, aren't you";

            var doWork = new ReverseWordsService().ReverseWords(inputStr);

            Assert.AreEqual(doWork, "uoY'er wen ereh, nera't uoy");
        }
    }
}
