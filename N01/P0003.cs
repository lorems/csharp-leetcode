using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.N01
{
    class P0003
    {
        // Runtime: 220 ms, faster than 27.37%
        public int LengthOfLongestSubstring(string s)
        {
            int leftPointer = 0;
            var set = new HashSet<char>();
            int max = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (set.Contains(s[i]))
                {
                    max = Math.Max(max, set.Count);

                    set.Clear();
                    ++leftPointer;
                    i = leftPointer;
                }
                set.Add(s[i]);
            }

            return Math.Max(set.Count, max);
        }

        // Runtime: 104 ms, faster than 85.26%
        public int LengthOfLongestSubstring2(string s)
        {
            int leftPointer = 0, rightPointer = 0; ;
            var set = new HashSet<char>();
            int max = 0;

            while (leftPointer < s.Length && rightPointer < s.Length)
            {
                if (set.Contains(s[rightPointer]))
                {
                    max = Math.Max(max, set.Count);
                    set.Remove(s[leftPointer++]);
                }
                else
                {
                    set.Add(s[rightPointer++]);
                }
            }

            return Math.Max(set.Count, max);
        }

        public void Run()
        {
            //string str = "qrsvbspk";
            //string str = "pwwkew";
            string str = "bbbb";

            int result = LengthOfLongestSubstring(str);
            Console.WriteLine(result);
        }
    }
}
