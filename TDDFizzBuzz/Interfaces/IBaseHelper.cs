using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDFizzBuzz.Interfaces
{
    //we have two parts to every part of fizzbuzz, our divisor, then returning our string.
    public interface IBaseHelper
    {
       public int divisor { get; }
        public string ParseUserInput(int input);
    }
}
