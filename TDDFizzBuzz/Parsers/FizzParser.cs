using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDFizzBuzz.Interfaces;

namespace TDDFizzBuzz.Parsers
{
    public class FizzParser : IBaseHelper
    {
        public int divisor => 3;

        public string ParseUserInput(int input)
        {
            if(input % divisor == 0)
            {
                return "Fizz";
            }
            return input.ToString();
        }
    }
}
