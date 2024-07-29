using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDFizzBuzz.Interfaces;

namespace TDDFizzBuzz.Parsers
{
    public class BuzzParser : IBaseHelper
    {
        public int divisor => 5;

        public string ParseUserInput(int input)
        {
            if (input % divisor == 0)
            {
                return "Buzz";
            }
            return input.ToString();
        }
    }
   
}
