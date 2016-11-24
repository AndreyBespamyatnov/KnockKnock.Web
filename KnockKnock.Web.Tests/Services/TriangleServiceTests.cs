using System.Collections.Generic;
using System.Linq;
using KnockKnock.Web.Services.Triangle;
using KnockKnock.Web.Services.Triangle.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KnockKnock.Web.Tests.Services
{
    [TestClass]
    public class TriangleServiceTests
    {
        [TestMethod]
        public void TestMethod_01()
        {
            var triangleService = new TriangleService();
            var resultsList = new List<TriangleType>
            {
                triangleService.GetTriangleType(new Triangle(0, 0, 0)),
                triangleService.GetTriangleType(new Triangle(1,1,2)),
                triangleService.GetTriangleType(new Triangle(-1,-1,-1)),
                triangleService.GetTriangleType(new Triangle(-1,0,1)),
                triangleService.GetTriangleType(new Triangle(1,1,-1)),
                triangleService.GetTriangleType(new Triangle(9, 9, 9999)),
                triangleService.GetTriangleType(new Triangle(1, 1, int.MaxValue)),
                triangleService.GetTriangleType(new Triangle(int.MinValue, int.MinValue, int.MinValue)),
                triangleService.GetTriangleType(new Triangle(4, 4, 8)),
                triangleService.GetTriangleType(new Triangle(5, 6, 13))
            };

            Assert.IsTrue(resultsList.All(r => r == TriangleType.Error));
        }

        [TestMethod]
        public void TestMethod_02()
        {
            var triangleService = new TriangleService();
            var resultsList = new List<TriangleType>
            {
                triangleService.GetTriangleType(new Triangle(1, 1, 1)),
                triangleService.GetTriangleType(new Triangle(int.MaxValue, int.MaxValue, int.MaxValue)),
            };

            Assert.IsTrue(resultsList.All(r => r == TriangleType.Equilateral));
        }

        [TestMethod]
        public void TestMethod_03()
        {
            var triangleService = new TriangleService();
            var resultsList = new List<TriangleType>
            {
                triangleService.GetTriangleType(new Triangle(5, 6, 7)),
                triangleService.GetTriangleType(new Triangle(7, 6, 5)),
                triangleService.GetTriangleType(new Triangle(6, 5, 7))
            };

            Assert.IsTrue(resultsList.All(r => r == TriangleType.Scalene));
        }

        [TestMethod]
        public void TestMethod_04()
        {
            var triangleService = new TriangleService();
            var resultsList = new List<TriangleType>
            {
                triangleService.GetTriangleType(new Triangle(4, 4, 6)),
                triangleService.GetTriangleType(new Triangle(int.MaxValue, 1, int.MaxValue)),
                triangleService.GetTriangleType(new Triangle(11, 1, 11)),
            };

            Assert.IsTrue(resultsList.All(r => r == TriangleType.Isosceles));
        }


    }
}
