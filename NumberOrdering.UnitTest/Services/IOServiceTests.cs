using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberOrdering.DataModel.Services;
using System;
using System.IO;

namespace NumberOrdering.UnitTest.Services
{
    [TestClass]
    public class IOServiceTests
    {
        [TestMethod]
        public void ReadAllNumbersAsync_InvalidPath_ThrowsException()
        {
            IOService _ioService = new IOService("");

            Assert.ThrowsException<ArgumentException>(_ioService.ReadAllNumbersAsync);
        }

        [TestMethod]
        public void ReadAllNumbersAsync_ValidPathEmptyFile_EmptyArray()
        {
            string filePath = "..\\..\\Mock\\EmptyFile.txt";
            IOService _ioService = new IOService(filePath);

            var results = _ioService.ReadAllNumbersAsync();

            Assert.AreEqual(0, results.Length);
        }

        [TestMethod]
        public void ReadAllNumbersAsync_ValidPathValidFile_ReturnsArray()
        {
            string filePath = "..\\..\\Mock\\ValidFile.txt";
            IOService _ioService = new IOService(filePath);

            var results = _ioService.ReadAllNumbersAsync();

            Assert.AreEqual(5, results.Length);
            Assert.AreEqual(1, results[0]);
            Assert.AreEqual(2, results[1]);
            Assert.AreEqual(3, results[2]);
            Assert.AreEqual(4, results[3]);
            Assert.AreEqual(5, results[4]);
        }

        [TestMethod]
        public void SaveNumbersAsync_InvalidPath_ThrowsException()
        {
            IOService _ioService = new IOService("");
            var numbers = new int[] { 1, 2, 3, 4 };
            
            Assert.ThrowsException<ArgumentException>(() => _ioService.SaveNumbersAsync(numbers));
        }

        [TestMethod]
        public void SaveNumbersAsync_ValidPath_SavesNumbers()
        {
            string filePath = "..\\..\\Mock\\OutputFile.txt";
            IOService _ioService = new IOService(filePath);
            var numbers = new int[] { 1, 2, 3, 4 };

            _ioService.SaveNumbersAsync(numbers);

            var text = File.ReadAllText(filePath);
            var expectedResult = text.Replace("\n", "").Replace("\r", "");

            Assert.AreEqual("1,2,3,4", expectedResult);
        }


    }
}
