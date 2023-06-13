using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_DepInjectionDemo
{
    public interface INumberService
    {
        int GetPositiveNumber();
    }

    public class NumberService : INumberService
    {
        private readonly INumberRepository _repo;

        public NumberService(INumberRepository repo) => _repo = repo;

        public int GetPositiveNumber()
        {
            int number = _repo.GetNumber();
            return Math.Abs(number);
        }
    }
}
