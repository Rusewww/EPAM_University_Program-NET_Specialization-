using System;
using System.Collections.Generic;
using System.Linq;

namespace Extension
{
    public static class MyExtension
    {
        /// <summary>
        /// Method that returns the sum of the digits of an arbitrary integer.
        /// </summary>        
        /// <param name="n">Integer parameter</param>
        /// <returns>Integer value</returns>
        public static int SummaDigit(this int n)
        {
            int sum = 0;
            n = Math.Abs(n);

            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }

            return sum;
        }

        /// <summary>
        /// Method that returns the sum of the original positive integer with the number obtained from the original by rearranging all digits in reverse order.
        /// </summary>
        /// <param name="n">Unsigned integer parameter</param>
        /// <returns>Unsigned long value</returns>
        public static ulong SummaWithReverse(this uint n)
        {
            string str = n.ToString();
            string reverseStr = new string(str.Reverse().ToArray());
            uint reverseNum = uint.Parse(reverseStr);
            return (ulong)n + (ulong)reverseNum;
        }

        /// <summary>
        /// Method that returns the number of characters in the string that are not Latin letters.
        /// </summary>
        /// <param name="str">String parameter</param>
        /// <returns>Integer value</returns>
        public static int CountNotLetter(this string str)
        {
            return str.Count(c => !Char.IsLetter(c) || c > 127);
        }

        /// <summary>
        /// Method that returns true if it is a weekend (Saturday or Sunday) or false if it is a weekday.
        /// </summary>
        /// <param name="day">DayOfWeek parameter</param>
        /// <returns>Boolean value</returns>
        public static bool IsDayOff(this DayOfWeek day)
        {
            return day == DayOfWeek.Saturday || day == DayOfWeek.Sunday;
        }

        /// <summary>
        /// Method that returns only even positive numbers from a set of integers.
        /// </summary>
        /// <param name="numbers">IEnumerable of integer elements</param>
        /// <returns>IEnumerable of integer elements</returns>
        public static IEnumerable<int> EvenPositiveElements(this IEnumerable<int> numbers)
        {
            return numbers.Where(x => x > 0 && x % 2 == 0);
        }
    }
}
