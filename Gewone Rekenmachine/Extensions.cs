using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Gewone_Rekenmachine
{
    public static class Extensions
    {
        public static Match[] Reverse(this MatchCollection col)
        {
            Match[] arr_matches = new Match[col.Count];
            col.CopyTo(arr_matches, 0);
            return arr_matches.Reverse().ToArray();
        }
        public static string Delete(this string str, int count)
        {
            if (count > str.Length) return "";
            return str.Substring(0, str.Length - count);
        }
        public static string Reverse(this string input)
        {
            return new string(input.ToCharArray().Reverse().ToArray());
        }
        public static decimal Sqrt(this decimal d)
        {
            if (d < 0) throw new OverflowException("Cannot calculate square root from a negative number");

            decimal current = (decimal)Math.Sqrt((double)d), previous;
            do
            {
                previous = current;
                if (previous == 0.0M) return 0;
                current = (previous + d / previous) / 2;
            }
            while (Math.Abs(previous - current) > 0.0M);
            return current;
        }
    }
}
