using NumberOrdering.DataModel.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace NumberOrdering.DataModel.Services
{
    public class IOService : IIOService
    {
        private string filePath { get; set; }

        public IOService(string filePath)
        {
            this.filePath = filePath ?? throw new ArgumentNullException();
        }

        public int[] ReadAllNumbersAsync()
        {
            var text = File.ReadAllText(filePath);
            if (!text.Contains(","))
            {
                return new int[] { };
            }

            var stringArray = text.Split(',');
            var response = new int[stringArray.Length];
            for(int i = 0; i < stringArray.Length; i++)
            {
                response[i] = int.Parse(stringArray[i]);
            }

            return response;
        }

        public void SaveNumbersAsync(IEnumerable<int> numbers)
        {
            string numbersToString = "";
            foreach(var number in numbers)
            {
                numbersToString += number.ToString() + ",";
            }

            var finalString = numbersToString.Substring(0, numbersToString.Length - 1);


            using (StreamWriter file = new StreamWriter(filePath, append: false)) 
            {
                file.WriteLine(finalString);
            }
        }
    }
}
