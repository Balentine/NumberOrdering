using NumberOrdering.DataModel.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace NumberOrdering.DataModel.Services
{
    public class InsertionSorting : ISortingService
    {
        private readonly IIOService _ioService;

        public InsertionSorting(IIOService ioService)
        {
            _ioService = ioService;
        }

        public void SaveNumbers(int[] numbers)
        {
            _ioService.SaveNumbersAsync(numbers);
        }

        public async Task<int[]> SortNumbers(List<int> numbers)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int n = numbers.Count;
            for (int i = 1; i < n; ++i)
            {
                int key = numbers[i];
                int j = i - 1;

                while (j >= 0 && numbers[j] > key)
                {
                    numbers[j + 1] = numbers[j];
                    j = j - 1;
                }
                numbers[j + 1] = key;
            }

            stopwatch.Stop();
            var elapsedTime = stopwatch.ElapsedMilliseconds;

            SaveNumbers(numbers.ToArray());

            return numbers.ToArray();
        }
    }
}
