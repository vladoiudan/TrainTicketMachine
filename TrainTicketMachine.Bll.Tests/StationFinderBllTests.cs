using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TrainTicketMachine.Bll.DataStructures;
using TrainTicketMachine.Bll.Interfaces;

namespace TrainTicketMachine.Bll.Tests
{
    [TestClass]
    public class StationFinderBllTests
    {
        private StationFinderBll _stationFinderBll;
        private Mock<IStationRepository> _stationFinderMock;
        private Mock<IPrefixTree> _prefixTreeMock;

        [TestInitialize]
        public void TestInit()
        {
            _stationFinderMock = new Mock<IStationRepository>();
            _prefixTreeMock = new Mock<IPrefixTree>();
            _stationFinderBll = new StationFinderBll(_stationFinderMock.Object, _prefixTreeMock.Object);
        }

        [TestMethod]
        public void TestConstructorLoadsUpTheTree()
        {
            _stationFinderMock = new Mock<IStationRepository>();
            _stationFinderMock.Setup(x => x.AllStations()).Verifiable();
            _prefixTreeMock.Setup(x => x.Add(It.IsAny<IEnumerable<string>>())).Verifiable();
            _stationFinderBll = new StationFinderBll(_stationFinderMock.Object, _prefixTreeMock.Object);
            _prefixTreeMock.VerifyAll();
            _stationFinderMock.VerifyAll();
        }

        [TestMethod]
        public async Task TestGetAllStartingWithCallTheRightMethodOnPrefixTree()
        {
            const string searchFilter = "a";
            _prefixTreeMock.Setup(x => x.FindAsync(It.Is<string>(t => t == searchFilter))).ReturnsAsync(new List<string>()).Verifiable();
            var task= await _stationFinderBll.GetAllStartingWith(searchFilter);
            _prefixTreeMock.VerifyAll();
        }
    }
}