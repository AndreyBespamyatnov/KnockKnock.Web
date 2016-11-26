using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Owin.Hosting;
using System.Net.Http;
using System.Linq;
using System.Net;
using KnockKnock.Web.Services.Triangle.Models;

namespace KnockKnock.Web.Tests
{
    [TestClass]
    public class ControllersOwinTests
    {
        private static Random random = new Random();
        private class HttpRespose
        {
            public string Message { get; set; }
        }


        [TestMethod]
        public void CallAzureService_ValidInput_OK()
        {
            HttpClient client = new HttpClient();
            const string productionUrl = "http://knockknockweb20161123094859.azurewebsites.net/";
            const string apiMethodToGet = "api/Token";
            var response = client.GetAsync(productionUrl + apiMethodToGet).Result;
            Assert.IsNotNull(response);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public void FibonacciGet_ValidInput_OK()
        {
            MakeControllerAction($"api/Fibonacci/?n={9}", "OK", result =>
            {
                Assert.AreEqual("34", result);
            });
        }

        [TestMethod]
        public void FibonacciGet_Exception_BadRequest()
        {
            MakeControllerAction($"api/Fibonacci/?n={-100}", "Bad Request", result =>
            {
                var resultObject = Newtonsoft.Json.JsonConvert.DeserializeObject<HttpRespose>(result);
                Assert.IsTrue(resultObject.Message.StartsWith("Value cannot be less than -92."));
            });
        }

        [TestMethod]
        public void ReverseWordsGet_ValidInput_OK()
        {
            MakeControllerAction($"api/ReverseWords/?sentence={"'Föobar Приве, однако мы стобой сказали: 'Хай хой'__ __ __'"}", "OK", result =>
            {
                Assert.AreEqual("\"'raboöF евирП, окандо ым йоботс илазакс: 'йаХ йох'__ __ __'\"", result);
            });
        }

        [TestMethod]
        [ExpectedException(typeof(UriFormatException), "Invalid URI: The Uri string is too long.")]
        public void ReverseWordsGet_Exception_BadRequest()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var longString = new string(Enumerable.Repeat(chars, 10000000).Select(s => s[random.Next(s.Length)]).ToArray());
            MakeControllerAction($"api/ReverseWords/?sentence={longString}", "Bad Request", result => { });
        }

        [TestMethod]
        public void TokenGet_ValidInput_OK()
        {
            MakeControllerAction($"api/Token/", "OK", result =>
            {
                Assert.AreEqual("\"998d1f95-93f2-4ea7-9a3f-e3ce80638b51\"", result);
            });
        }

        [TestMethod]
        public void TriangleTypeGet_ValidInput_OK()
        {
            MakeControllerAction($"api/TriangleType/?a=0&b=0&c=0", "OK", result =>
            {
                Assert.AreEqual($"\"{TriangleType.Error.ToString()}\"", result);
            });
        }

        private void MakeControllerAction(string url, string reasonPhrase, Action<string> assentAction)
        {
            string baseAddress = "http://localhost:9000/";
            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                // Create HttpCient and make a request to api/values 
                HttpClient client = new HttpClient();

                var response = client.GetAsync(baseAddress + url).Result;

                Assert.IsNotNull(response);
                Assert.AreEqual(response.ReasonPhrase, reasonPhrase);

                var resultValue = response.Content.ReadAsStringAsync().Result;

                Assert.IsNotNull(resultValue);

                assentAction.Invoke(resultValue);
            }
        }
    }
}
