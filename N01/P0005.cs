using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.N01
{
    class P0005
    {
        // O(n^2)

        // Runtime: 188 ms, faster than 48.30%
        // Memory Usage: 12.5 MB, less than 29.48%
        public string LongestPalindrome(string s)
        {
            if (s.Length <= 1)
                return s;

            s = string.Join("", s.Zip(s, (a, b) => "#" + b.ToString()).ToArray()) + "#";
            string result = "";

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 1; j <= Math.Min(i, s.Length-i); j++)
                {
                    if (i+j == s.Length)
                        break;

                    if (s[i-j] == s[i+j])
                    {
                        int tempLength = (j - 1) * 2 + 3;
                        if (tempLength > result.Length)
                            result = s.Substring(i - j, tempLength);
                    }
                    else
                        break;
                }
            }
            return result.Replace("#","");
        }
        // O(n^2)

        // Runtime: 2808 ms, faster than 3.54%
        // Memory Usage: 36.1 MB, less than 21.10%
        public string LongestPalindrome2(string s)
        {
            if (s.Length == 0)
                return s;

            int resLength = 0;
            int start = 0, end = 0;
            LinkedList<char> current = new LinkedList<char>();
            LinkedList<char> reverse = new LinkedList<char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (resLength > s.Length - i)
                    break;

                for (int j = i; j < s.Length; j++)
                {
                    if (resLength > s.Length - j +1)
                        break;

                    if (i == j)
                    {
                        current.AddFirst(s[i]);
                        reverse.AddFirst(s[i]);
                    }
                    else
                    {
                        current.AddLast(s[j]);
                        reverse.AddFirst(s[j]);
                    }

                    if (current.Count > resLength && current.SequenceEqual(reverse))
                    {
                        start = i;
                        end = j;
                        resLength = current.Count;
                    }
                }
                current.Clear();
                reverse.Clear();
            }

            return s.Substring(start, end - start + 1);
        }
        
        public void Run()
        {
            Console.WriteLine(LongestPalindrome("zzabawwc"));
            Console.WriteLine(LongestPalindrome("cb"));
            Console.WriteLine(LongestPalindrome("bb"));
            Console.WriteLine(LongestPalindrome("a"));
            Console.WriteLine(LongestPalindrome("cbbd"));
            Console.WriteLine(LongestPalindrome("zzabawwc"));
            Console.WriteLine(LongestPalindrome(""));
            Console.WriteLine(LongestPalindrome("zzaba"));
            Console.WriteLine(LongestPalindrome("abcba"));
            Console.WriteLine(LongestPalindrome("bbb"));
            Console.WriteLine(LongestPalindrome("babad"));
            
            
            
            string lo = "jrjnbctoqgzimtoklkxcknwmhiztomaofwwzjnhrijwkgmwwuazcowskjhitejnvtblqyepxispasrgvgzqlvrmvhxusiqqzzibcyhpnruhrgbzsmlsuacwptmzxuewnjzmwxbdzqyvsjzxiecsnkdibudtvthzlizralpaowsbakzconeuwwpsqynaxqmgngzpovauxsqgypinywwtmekzhhlzaeatbzryreuttgwfqmmpeywtvpssznkwhzuqewuqtfuflttjcxrhwexvtxjihunpywerkktbvlsyomkxuwrqqmbmzjbfytdddnkasmdyukawrzrnhdmaefzltddipcrhuchvdcoegamlfifzistnplqabtazunlelslicrkuuhosoyduhootlwsbtxautewkvnvlbtixkmxhngidxecehslqjpcdrtlqswmyghmwlttjecvbueswsixoxmymcepbmuwtzanmvujmalyghzkvtoxynyusbpzpolaplsgrunpfgdbbtvtkahqmmlbxzcfznvhxsiytlsxmmtqiudyjlnbkzvtbqdsknsrknsykqzucevgmmcoanilsyyklpbxqosoquolvytefhvozwtwcrmbnyijbammlzrgalrymyfpysbqpjwzirsfknnyseiujadovngogvptphuyzkrwgjqwdhtvgxnmxuheofplizpxijfytfabx";
            Console.WriteLine(LongestPalindrome(lo)); // qosoq            
            Console.WriteLine(LongestPalindrome("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb"));
        }
    }
}
