using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDFizzBuzz.Interfaces;

namespace TDDFizzBuzz.Parsers
{
    public class FizzBuzzParser : IBaseHelper
    {
        //this is divisble by both 3 and 15 as its our least common multiple :)
        public int divisor => 15;

        public string ParseUserInput(int input)
        {
            if (input % divisor == 0)
            {
                return "FizzBuzz";
            }
            return input.ToString();
        }
    }
}
