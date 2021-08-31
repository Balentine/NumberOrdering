using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NumberOrdering.DataModel.Services.Interfaces
{
    public interface ISortingService
    {
        Task<int[]> SortNumbers(List<int> numbers);
        void SaveNumbers(int[] numbers);
    }
}
