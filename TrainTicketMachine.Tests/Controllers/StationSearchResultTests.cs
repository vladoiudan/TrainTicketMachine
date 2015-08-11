using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainTicketMachine.Entities;

namespace TrainTicketMachine.Tests.Controllers
{
    [TestClass]
    public class StationSearchResultTests
    {
        [TestMethod]
        public void TestNewInstanceOfStationResultSetsThePropertiesCorrectly()
        {
            // Arrange
            var nextChars = new List<char>() { 'a' };
            var stations = new List<string>() { "aa" };

            // Act
            var result = new StationSearchResult(nextChars, stations);

            // Assert
            Assert.IsTrue(result.NextPossibleCharacters.Equals(nextChars));
            Assert.IsTrue(result.Stations.Equals(stations));
        }

        [TestMethod]
        public void TestNewInstanceOfStationResultSetsWithNullParamsSetsThePropertiesCorrectly()
        {
            // Arrange
            var nextChars = new List<char>() { 'a' };
            var stations = new List<string>() { "aa" };

            // Act
            var result = new StationSearchResult(null, null);

            // Assert
            Assert.IsNotNull(result.NextPossibleCharacters);
            Assert.IsNotNull(result.Stations);
        }
    }
}