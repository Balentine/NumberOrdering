using NumberOrdering.DataModel.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace NumberOrdering.DataModel.Services
{
    public class SelectionSorting : ISortingService
    {
        private readonly IIOService _ioService;

        public SelectionSorting(IIOService ioService)
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

            var orderedList = new int[numbers.Count];
            int index = 0;
            while (numbers.Count > 0)
            {
                int minimumNumber = numbers[0];

                for (int i = 1; i < numbers.Count; i++)
                {
                    if (numbers[i] < minimumNumber)
                    {
                        minimumNumber = numbers[i];
                    }
                }

                orderedList[index] = minimumNumber;
                numbers.RemoveAt(numbers.IndexOf(minimumNumber));
                index++;
            }

            stopwatch.Stop();
            var elapsedTime = stopwatch.ElapsedMilliseconds;

            SaveNumbers(orderedList);

            return orderedList;
        }
    }
}
