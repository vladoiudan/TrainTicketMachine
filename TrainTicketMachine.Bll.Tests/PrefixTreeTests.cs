using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrainTicketMachine.Bll.DataStructures;

namespace TrainTicketMachine.Bll.Tests
{
    [TestClass]
    public class PrefixTreeTests
    {
        [TestMethod]
        public async Task TestTreeAddWithSingleCharStringTerm()
        {
            // Arrange
            var items = new[] { "A" };
            var tree = new PrefixTree();
            var expected = items;

            // Act
            tree.Add(items);
            var actual = await tree.FindAsync(string.Empty);
            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count(), expected.Where(actual.Contains).Count());
        }

        [TestMethod]
        public async Task TestTreeAddWithSingleTerm()
        {
            // Arrange
            var items = new[] { "aB" };
            var tree = new PrefixTree();
            var expected = items;

            // Act
            tree.Add(items);
            var actual =await tree.FindAsync(string.Empty);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count(), expected.Count(x => actual.Contains(x.ToUpper())));
        }

        [TestMethod]
        public async Task TestTreeAddWithMultipleItemsStartedWithSamePrefix()
        {
            // Arrange
            var items = new[] { "AbC", "ABcD" };
            var tree = new PrefixTree();
            var expected = items;

            // Act
            tree.Add(items);
            var actual =await tree.FindAsync(string.Empty);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count(), expected.Count(x => actual.Contains(x.ToUpper())));

        }

        [TestMethod]
        public async Task TestGetItemsWithSingleChar()
        {
            // Arrange
            var items = new[] { "A" };
            var tree = new PrefixTree();
            tree.Add(items);

            var expected = items;

            // Act
            var actual =await tree.FindAsync("A");

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count(), expected.Where(actual.Contains).Count());
        }

        [TestMethod]
        public async Task TestGetItemsWithSingleCharAndMultipleBranches()
        {
            // Arrange
            var items = new[] { "ABCD", "AdCE" };
            var tree = new PrefixTree();
            tree.Add(items);

            var expected = items;

            // Act
            var actual =await tree.FindAsync("A");

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count(), expected.Count(x => actual.Contains(x.ToUpper())));
        }

        [TestMethod]
        public async Task TestGetItemsWithFullTerm()
        {
            // Arrange
            var items = new[] { "ABC" };
            var tree = new PrefixTree();
            tree.Add(items);

            var expected = items;

            // Act
            var actual =await tree.FindAsync("ABC");

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count(), expected.Where(actual.Contains).Count());
        }

        [TestMethod]
        public async Task TestGetItemsWithFullTermAndBranch()
        {
            // Arrange
            var items = new[] { "ABCD", "ABCDE" };
            var tree = new PrefixTree();
            tree.Add(items);

            var expected = items;

            // Act
            var actual =await tree.FindAsync("ABCD");

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count(), expected.Where(actual.Contains).Count());
        }

        [TestMethod]
        public async Task TestGetItemsWithPartialTermAndSingleBranche()
        {
            // Arrange
            var items = new[] { "ABCD" };
            var tree = new PrefixTree();
            tree.Add(items);

            var expected = items;

            // Act
            var actual =await tree.FindAsync("AB");

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count(), expected.Where(actual.Contains).Count());
        }

        [TestMethod]
        public async Task TestGetItemsWithPartialTermAndMultipleBranches()
        {
            // Arrange
            var items = new[] { "ABF", "ABE" };
            var tree = new PrefixTree();
            tree.Add(items);

            var expected = items;

            // Act
            var actual =await tree.FindAsync("Ab");

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count(), expected.Where(actual.Contains).Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task TestFindNullThrowsException()
        {

            // Arrange
            var items = new[] { "ABF", "ABE" };
            var tree = new PrefixTree();
            tree.Add(items);

            // Act
            await tree.FindAsync(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddNullThrowsException()
        {

            // Arrange
            var items = new[] { "as", null, "daf" };
            var tree = new PrefixTree();

            // Act
            tree.Add(items);
        }
    }
}
