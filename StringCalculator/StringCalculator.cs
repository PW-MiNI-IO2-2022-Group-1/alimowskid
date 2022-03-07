using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class StringCalculator
    {
        public static int CalculateString(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            var delimiters = new List<string>{ ",", "\n"};
            if(s.StartsWith("//"))
            {
                var parts = s.Split('\n', 2);
                if(parts[0].Contains('[') && parts[0].Contains(']')) {
                    delimiters.Add(parts[0][3..^1]);
                } else delimiters.Add(parts[0][2].ToString());
                s = parts[1];
            }

            int[] numbers = s.Split(delimiters.ToArray(), StringSplitOptions.None)
                .Select(str => int.Parse(str))
                .ToArray();
            if (numbers.Any(n => n < 0)) throw new ArgumentException("Negative number");
            return numbers.Where(n => n <= 1000).Sum() - 1;
        }
    }
}
