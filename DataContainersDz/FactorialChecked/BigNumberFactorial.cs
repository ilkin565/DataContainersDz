using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorialChecked
{
    public static class BigNumberFactorial
    {
        public static string Calculate(int n)
        {
            if (n < 0)
                throw new ArgumentException("Факториал отрицательного числа не определен");

            List<int> digits = new List<int> { 1 };

            for (int i = 2; i <= n; i++)
            {
                MultiplyDigits(digits, i);
            }

            return ConvertToString(digits);
        }

        private static void MultiplyDigits(List<int> digits, int multiplier)
        {
            int carry = 0;

            for (int i = 0; i < digits.Count; i++)
            {
                int product = digits[i] * multiplier + carry;
                digits[i] = product % 10;
                carry = product / 10;
            }

            while (carry > 0)
            {
                digits.Add(carry % 10);
                carry /= 10;
            }
        }

        private static string ConvertToString(List<int> digits)
        {
            var sb = new StringBuilder();
            for (int i = digits.Count - 1; i >= 0; i--)
            {
                sb.Append(digits[i]);
            }
            return sb.ToString();
        }
    }
}