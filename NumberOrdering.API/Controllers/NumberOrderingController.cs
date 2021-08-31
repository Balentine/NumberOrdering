using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NumberOrdering.DataModel.Services;
using NumberOrdering.DataModel.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NumberOrdering.API.Controllers
{
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ApiController]
    public class NumberOrderingController : ControllerBase
    {
        private readonly string filePath = ".\\Files\\TextFile.txt";
        IIOService _ioService;
        NumberSortingService _numberSortingService;
        public NumberOrderingController()
        {
            _ioService = new IOService(filePath);
            _numberSortingService = new NumberSortingService(_ioService);
        }

        [HttpGet]
        [Route("/numbers")]
        public IEnumerable<int> GetNumbers()
        {
            var response = _ioService.ReadAllNumbersAsync();
            
            return response;
        }

        [HttpPut]
        [Route("/bubble")]
        public string BubbleSortNumbersAndSave(List<int> numbers)
        {
            return "Elapsed time milliseconds: " + _numberSortingService.BubbleSortNumbers(numbers).Result.Item1;
        }

        [HttpPut]
        [Route("/selection")]
        public string SelectionSortNumbersAndSave(List<int> numbers)
        {
            return "Elapsed time milliseconds: " + _numberSortingService.SelectionSortNumbers(numbers).Result.Item1;
        }

        [HttpPut]
        [Route("/insertion")]
        public string InsertionSortNumbersAndSave(List<int> numbers)
        {
            return "Elapsed time milliseconds: " + _numberSortingService.InsertionSortNumbers(numbers).Result.Item1;
        }
    }
}
