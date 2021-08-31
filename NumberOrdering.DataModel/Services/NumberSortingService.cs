using NumberOrdering.DataModel.Services.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace NumberOrdering.DataModel.Services
{
    public class NumberSortingService
    {
        IIOService _ioService;
        ISortingService _bubbleSorting;
        ISortingService _selectionSorting;
        ISortingService _insertionSorting;
        public NumberSortingService(IIOService ioService)
        {
            _ioService = ioService;
            _bubbleSorting = new BubbleSorting(_ioService);
            _selectionSorting = new SelectionSorting(_ioService);
            _insertionSorting = new InsertionSorting(_ioService);
        }

        public async Task<(long, int[])> SelectionSortNumbers(List<int> numbers)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var orderedNumbers = await _selectionSorting.SortNumbers(numbers);

            stopwatch.Stop();

            var elapsedTime = stopwatch.ElapsedMilliseconds;

            return (elapsedTime, orderedNumbers);
        }

        public async Task<(long, int[])> BubbleSortNumbers(List<int> numbers)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var orderedNumbers = await _bubbleSorting.SortNumbers(numbers);

            stopwatch.Stop();

            var elapsedTime = stopwatch.ElapsedMilliseconds;

            return (elapsedTime, orderedNumbers);
        }

        public async Task<(long, int[])> InsertionSortNumbers(List<int> numbers)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var orderedNumbers = await _insertionSorting.SortNumbers(numbers);

            stopwatch.Stop();

            var elapsedTime = stopwatch.ElapsedMilliseconds;

            return (elapsedTime, orderedNumbers);
        }
    }
}
