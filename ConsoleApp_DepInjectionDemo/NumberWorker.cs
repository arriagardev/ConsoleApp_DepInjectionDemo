using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_DepInjectionDemo
{
    public class NumberWorker
    {
        private readonly INumberService _service;
        private readonly ILogger _logger;

        public NumberWorker(
            INumberService service,
            ILogger<NumberWorker> logger)
        {
            _service = service;
            _logger = logger;
        }

        public void PrintNumber()
        {
            var number = _service.GetPositiveNumber();
            _logger.LogInformation($"The number I found is {number}");
            Console.WriteLine($"My wonderful number is {number}");
        }

    }
}
