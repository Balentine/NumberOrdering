using Moq;
using NumberOrdering.DataModel.Services;
using NumberOrdering.DataModel.Services.Interfaces;
using System.Collections.Generic;
using Xunit;

namespace NumberOrdering.UnitTests.Services
{
    public class BubbleSortingTests
    {
        private readonly BubbleSorting bubbleSorting;
        private readonly Mock<IIOService> _ioService;

        public BubbleSortingTests()
        {
            _ioService = new Mock<IIOService>();
            bubbleSorting = new BubbleSorting(_ioService.Object);
        }

        [Fact]
        public async void SortNumbers_ValidNumbersList_SortsCorrectly()
        {
            var numbers = new List<int> { 3, 6, 4, 7, 2 };
            _ioService.Setup(service => service.SaveNumbersAsync(numbers));

            var result = await bubbleSorting.SortNumbers(numbers);

            Assert.Equal(new int[]{ 2,3,4,6,7}, result);
        }
    }
}
