using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException();
            else if (numbers == string.Empty)
                return 0;

            var parseNumbers = ParseInputString(numbers);
            int result = 0;

            foreach(string item in parseNumbers)
            {
                int number = Convert.ToInt32(item);

                if (number < 0)
                    throw new ArgumentException("Negatives not allowed");

                result += number;
            }

            return result;
        }

        private string[] ParseInputString(string line)
        {
            char defaultDelimiter = ',';

            if (line.StartsWith("//"))
            {
                defaultDelimiter = line[2];
                line = line.Substring(line.IndexOf('\n') + 1);
            }

            return line.Replace('\n', defaultDelimiter).Split(defaultDelimiter);
        }
    }
}
