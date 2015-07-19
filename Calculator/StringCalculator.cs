using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator
{
    public class StringCalculator : IStringCalculator
    {
        private static string DefaultDelimiter
        {
            get { return ","; }
        }

        public int Add(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return 0;
            }
            var numbers = Tokenize(input);
            ValidateInput(numbers);

            return numbers.Sum(i => i);
        }

        private static List<int> Tokenize(string input)
        {
            input = ReplaceUserSpecifiedDelimiterWithComma(input);
            input = ReplaceNewLineDelimiterWithComma(input);
            return input.Split(DefaultDelimiter.ToCharArray())
                        .Select(int.Parse)
                        .ToList();
        }

        private static string ReplaceNewLineDelimiterWithComma(string input)
        {
            input = input.Replace("\n", DefaultDelimiter);
            return input;
        }

        private static string ReplaceUserSpecifiedDelimiterWithComma(string input)
        {
            if (input.StartsWith("//"))
            {
                const string delimiterPattern = "//(.)\n";

                var regex = new Regex(delimiterPattern);
                var match = regex.Match(input);

                if (match.Success)
                {
                    var delimiter = match.Groups[1].Value;
                    input = regex.Replace(input, "");
                    return input.Replace(delimiter, DefaultDelimiter);
                }
            }
            return input;
        }

        private static void ValidateInput(IEnumerable<int> args)
        {
            var negativeNumbers = args.Where(i => i < 0).ToList();
            if (negativeNumbers.Any())
            {
                throw new ArgumentException("Negative numbers are not allowed: " + String.Join(DefaultDelimiter, negativeNumbers));
            }
        }

    }
}
