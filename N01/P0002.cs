using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.N01
{
    /**
     * Definition for singly-linked list.
     * public class ListNode {
     *     public int val;
     *     public ListNode next;
     *     public ListNode(int x) { val = x; }
     * }
     */

    public class ListNode : IEnumerable
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }

        public IEnumerator GetEnumerator()
        {
            var node = this;
            while (node != null)
            {
                yield return node.val;
                node = node.next;
            }
        }
    }

    class P0002
    {
        // Runtime: 132 ms, faster than 92.75%
        public ListNode AddTwoNumbers(ListNode node1, ListNode node2) 
        {
            ListNode currentNode = new ListNode(0);
            ListNode head = currentNode;
            int carry = 0;

            while (true)
            {
                int sum = node1.val + node2.val + carry;
                carry = (sum > 9) ? 1 : 0;
                sum = sum % 10;

                currentNode.val = sum;
                
                node1 = node1.next;
                node2 = node2.next;

                if (node1 == null && node2 == null) break;
                else if (node1 == null) node1 = new ListNode(0);
                else if (node2 == null) node2 = new ListNode(0);

                currentNode.next = new ListNode(0);
                currentNode = currentNode.next;
            }

            if (carry != 0)
            {
                currentNode.next = new ListNode(carry);
            }

            return head;
        }
        public void Run()
        {
            //var ln1 = new ListNode(2);
            //ln1.next = new ListNode(4);
            //ln1.next.next = new ListNode(3);

            var ln1 = new ListNode(1);
            ln1.next = new ListNode(2);
            ln1.next.next = new ListNode(4);
            ln1.next.next.next = new ListNode(3);

            //var ln1 = new ListNode(5);

            //var ln1 = new ListNode(1);
            //ln1.next = new ListNode(8);

            //****************************************//

            var ln2 = new ListNode(5);
            ln2.next = new ListNode(6);
            ln2.next.next = new ListNode(4);

            //var ln2 = new ListNode(5);

            //var ln2 = new ListNode(0);

            var result = AddTwoNumbers(ln1, ln2);
            //var result = ReverseListNode(ln1);


            foreach (var n in result)
            {
                Console.WriteLine(n);
            }
        }
    }
}
