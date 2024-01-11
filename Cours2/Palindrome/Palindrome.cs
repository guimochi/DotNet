using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome
{
    public static class Palindrome
    {
        public static bool IsAPalindrome(this string  s)
        {
            IEnumerable<char> reversed = s.Reverse();
            for (int i = 0; i < s.Length/2;  i++)
            {
                if (reversed.ElementAt(i) != s.ElementAt(i))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
