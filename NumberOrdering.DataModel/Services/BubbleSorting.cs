using NumberOrdering.DataModel.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace NumberOrdering.DataModel.Services
{
    public class BubbleSorting : ISortingService
    {
        private readonly IIOService _ioService;

        public BubbleSorting(IIOService ioService)
        {
            _ioService = ioService;
        }

        public void SaveNumbers(int[] numbers)
        {
            _ioService.SaveNumbersAsync(numbers);
        }

        public async Task<int[]> SortNumbers(List<int> numbers)
        {
            int[] orderedList = new int[numbers.Count];
            bool done = false;
            while (!done)
            {
                done = true;
                for (int i = 0; i < numbers.Count - 1; i++)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        var temp = numbers[i];
                        numbers[i] = numbers[i + 1];
                        numbers[i + 1] = temp;
                        done = false;
                    }
                }
            }

            for(int i = 0; i < numbers.Count; i++)
            {
                orderedList[i] = numbers[i];

            }

            SaveNumbers(orderedList);

            return orderedList;
        }
    }
}
