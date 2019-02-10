using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.N01
{
    public class P0001
    {
        // Runtime: 300 ms, faster than 82.48%
        public int[] TwoSum(int[] nums, int target)
        {
            int[] result = { 0, 0 };
            var dic = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(target - nums[i]))
                {
                    result[0] = dic[target - nums[i]];
                    result[1] = i;
                    break;
                }
                if (!dic.ContainsKey(nums[i]))
                    dic.Add(nums[i], i);
            }
            return result;
        }

        public void Run()
        {
            int[] nums = { 2, 7, 11, 15 };
            var res = TwoSum(nums, 9);
            //int[] nums = { 3,2,4 };
            //var res = TwoSum(nums, 6);

            Console.WriteLine(string.Join(";", res));
        }
    }
}
