using System.Collections.Generic;
using System.Threading.Tasks;

namespace NumberOrdering.DataModel.Services.Interfaces
{
    public interface IIOService
    {
        int[] ReadAllNumbersAsync();
        void SaveNumbersAsync(IEnumerable<int> numbers);
    }
}
