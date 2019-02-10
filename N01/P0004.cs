using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.N01
{
    class P0004
    {
        // Runtime: 160 ms, faster than 36.26%
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int[] arr = nums1.Concat(nums2).ToArray();
            Array.Sort(arr);

            if (arr.Length % 2 == 0)
                return (arr[arr.Length / 2 - 1] + arr[arr.Length / 2]) / 2.0;
            
            return arr[arr.Length / 2];
        }

        // Runtime: 148 ms, faster than 83.52%
        public double FindMedianSortedArrays2(int[] nums1, int[] nums2)
        {
            var list = new List<int>();
            int? cursor1 = (nums1.Length == 0) ? null : (int?)0;
            int? cursor2 = (nums2.Length == 0) ? null : (int?)0;

            for (int i = 0; i < nums1.Length + nums2.Length; i++)
            {
                if (cursor1 == null || cursor2 == null)
                {
                    if (cursor1 == null)
                        list.Add(nums2[(int)cursor2++]);
                    else
                        list.Add(nums1[(int)cursor1++]);
                }
                else
                {
                    if (nums1[(int)cursor1] < nums2[(int)cursor2])
                    {
                        list.Add(nums1[(int)cursor1]);
                        cursor1 = (cursor1 == nums1.Length - 1) ? null : ++cursor1;
                    }
                    else
                    {
                        list.Add(nums2[(int)cursor2]);
                        cursor2 = (cursor2 == nums2.Length - 1) ? null : ++cursor2;
                    }
                }
            }

            if (list.Count % 2 == 0)
                return (list[list.Count / 2 - 1] + list[list.Count / 2]) / 2.0;

            return list[list.Count / 2];
        }

        // #3 Runtime: 152 ms, faster than 62.64%
        public double FindMedianSortedArrays3(int[] nums1, int[] nums2)
        {
            var list = new List<int>();
            int? cursor1 = (nums1.Length == 0) ? null : (int?)0;
            int? cursor2 = (nums2.Length == 0) ? null : (int?)0;
            int totalLenght = nums1.Length + nums2.Length;
            int middleLength = totalLenght / 2 + 1;

            for (int i = 0; i < middleLength; i++)
            {
                if (cursor1 == null || cursor2 == null)
                {
                    if (cursor1 == null)
                        list.Add(nums2[(int)cursor2++]);
                    else
                        list.Add(nums1[(int)cursor1++]);
                }
                else
                {
                    if (nums1[(int)cursor1] < nums2[(int)cursor2])
                    {
                        list.Add(nums1[(int)cursor1]);
                        cursor1 = (cursor1 == nums1.Length - 1) ? null : ++cursor1;
                    }
                    else
                    {
                        list.Add(nums2[(int)cursor2]);
                        cursor2 = (cursor2 == nums2.Length - 1) ? null : ++cursor2;
                    }
                }
            }

            if (totalLenght % 2 == 0)                
                return (list[list.Count - 1] + list[list.Count - 2]) / 2.0;
            return list[list.Count - 1];
        }

        public void Run()
        {
            // 1, 2, 3 => 2
            //int[] nums1 = { 1, 3 };
            //int[] nums2 = { 2 };

            // 1, 2, 3, 4 => 2.5
            //int[] nums1 = { 1, 2 };
            //int[] nums2 = { 3, 4 };

            // 1, 3 => 2.0
            int[] nums1 = { 1, 3 };
            int[] nums2 = {  };

            double d = FindMedianSortedArrays3(nums1, nums2);

            Console.WriteLine(d);
        }
    }
}
