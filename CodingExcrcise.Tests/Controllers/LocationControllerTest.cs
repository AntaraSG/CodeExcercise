using CodingExcrcise.Controllers;
using CodingExcrcise.Models;
using CodingExcrcise.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Web.Mvc;

namespace CodingExcrcise.Tests.Controllers
{
    [TestClass]
    class LocationControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var mock = new Mock<ILocationRepository>();
            
            LocationController controller = new LocationController(mock.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Pollution ()
        {
            var mock = new Mock<ILocationRepository>();
            var location = new Location { Coordinate = new Coordinate { Latitude = 30, Longitude = 50 } };

            // Act
            var model = mock.Object.GetCityPolution(location, DateTime.Now);

            // Assert
            Assert.IsNotNull(model);
        }
    }
}
