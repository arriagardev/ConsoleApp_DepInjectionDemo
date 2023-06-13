using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_DepInjectionDemo
{
    public interface INumberRepository
    {
        int GetNumber();
    }

    public class NumberRepository : INumberRepository
    {
        private readonly NumberConfig _config;

        public NumberRepository(IOptions<NumberConfig> options)
        {
            _config= options.Value;
        }

        public int GetNumber()
        {
            return _config.DefaultNumber;
        }
    }
}
