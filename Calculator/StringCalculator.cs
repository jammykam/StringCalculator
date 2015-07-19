using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class StringCalculator : IStringCalculator
    {
        public int Add(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return 0;
            }

            return int.Parse(input);
        }
    }
}
