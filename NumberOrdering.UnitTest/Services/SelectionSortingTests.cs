using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NumberOrdering.DataModel.Services;
using NumberOrdering.DataModel.Services.Interfaces;
using System.Collections.Generic;

namespace NumberOrdering.UnitTests.Services
{
    [TestClass]
    public class SelectionSortingTests
    {
        private readonly SelectionSorting selectionSorting;
        private readonly Mock<IIOService> _ioService;

        public SelectionSortingTests()
        {
            _ioService = new Mock<IIOService>();
            selectionSorting = new SelectionSorting(_ioService.Object);
        }

        [TestMethod]
        public void SortNumbers_ValidNumbersList_SortsCorrectly()
        {
            var numbers = new List<int> { 3, 6, 4, 7, 2 };

            var result = selectionSorting.SortNumbers(numbers);

            Assert.AreEqual(5, result.Result.Length);
            Assert.AreEqual(2, result.Result[0]);
            Assert.AreEqual(3, result.Result[1]);
            Assert.AreEqual(4, result.Result[2]);
            Assert.AreEqual(6, result.Result[3]);
            Assert.AreEqual(7, result.Result[4]);
        }

        [TestMethod]
        public void SortNumbers_EmptyNumbersList_ReturnsEmpty()
        {
            var numbers = new List<int> {};

            var result = selectionSorting.SortNumbers(numbers);

            Assert.AreEqual(0, result.Result.Length);
        }
    }
}
