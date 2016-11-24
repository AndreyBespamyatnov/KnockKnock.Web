using System;
using System.Collections.Generic;
using System.Linq;
using KnockKnock.Web.Services.Fibanacci;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KnockKnock.Web.Tests.Services
{
    [TestClass]
    public class FibonachiServiceTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var service = new FibonachiService();
            var resultList = new Dictionary<long, long>
            {
                {service.GetNumber(-92), -7540113804746369024},
                {service.GetNumber(-75), 2111485077978055},
                {service.GetNumber(-55), 139583862445},
                {service.GetNumber(-20), -6765},
                {service.GetNumber(-11), 89},
                {service.GetNumber(-4), -3},
                {service.GetNumber(0), 0},
                {service.GetNumber(1), 1},
                {service.GetNumber(9), 34},
                {service.GetNumber(21), 10946},
                {service.GetNumber(38), 39088169},
                {service.GetNumber(51), 20365011074},
                {service.GetNumber(69), 117669030460994},
                {service.GetNumber(92), 7540113804746369024}
            };

            Assert.IsTrue(resultList.All(pair => pair.Key == pair.Value));
        }

        [TestMethod]
        public void TestMethod2()
        {
            var service = new FibonachiService();
            try
            {
                service.GetNumber(-93);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentOutOfRangeException);
            }

            try
            {
                service.GetNumber(93);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentOutOfRangeException);
            }
        }
    }
}
