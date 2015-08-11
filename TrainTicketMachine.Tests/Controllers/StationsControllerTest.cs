using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TrainTicketMachine.Bll.Interfaces;
using TrainTicketMachine.Bll.Repository;
using TrainTicketMachine.Controllers;
using TrainTicketMachine.Entities;

namespace TrainTicketMachine.Tests.Controllers
{
    [TestClass]
    public class StationsControllerTest
    {
        private Mock<IStationFinderBll> _stationFinderBllMock;

        [TestInitialize]
        public void TestInit()
        {
            _stationFinderBllMock = new Mock<IStationFinderBll>();
        }

        [TestMethod]
        public async Task TestGetCallsCorrectBllMethod()
        {
            // Arrange
            _stationFinderBllMock.Setup(x => x.GetAllStartingWith(It.IsAny<string>())).ReturnsAsync(new List<string>()).Verifiable();
            var controller = new StationsController(_stationFinderBllMock.Object);

            // Act
            StationSearchResult result = await controller.Get(string.Empty);

            // Assert
            Assert.IsNotNull(result);
           _stationFinderBllMock.VerifyAll();
        }

        [TestMethod]
        public async Task TestGetCallsCorrectBllMethodWIthCorrectParameter()
        {
            const string searchFilter = "t";

            // Arrange
            _stationFinderBllMock.Setup(x => x.GetAllStartingWith(It.Is<string>(t => t == searchFilter))).ReturnsAsync(new List<string>(){"test"}).Verifiable();
            var controller = new StationsController(_stationFinderBllMock.Object);

            // Act
            StationSearchResult result =await controller.Get(searchFilter);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Stations.Count() == 1);
            Assert.IsTrue(result.NextPossibleCharacters.Count() == 1);
            _stationFinderBllMock.VerifyAll();
        }

    }
}
