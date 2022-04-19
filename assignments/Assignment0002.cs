
using System.Text;

namespace leetcode
{
    class Assignment0002
    {
        public static void Run()
        {
            // Input: l1 = [2,4,3], l2 = [5,6,4]
            // Output: [7,0,8]
            // Explanation: 342 + 465 = 807.

            // Input: l1 = [1,4,3], l2 = [5,6,4]
            // Output: [6,0,8]
            // Explanation: 341 + 465 = 806.

            // var l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
            // var l2 = new ListNode(6, new ListNode(4));
            var l1 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9)))))));
            var l2 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))));
            var sum = (new Assignment0002()).AddTwoNumbers(l1, l2);
            System.Console.WriteLine($"{l1} + {l2} = {sum}");
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode res = new ListNode();
            ListNode sum = res;
            var overflow = 0;

            while (l1 != null || l2 != null)
            {
                if (l1 != null)
                {
                    sum.val += l1.val;
                }

                if (l2 != null)
                {
                    sum.val += l2.val;
                }

                if (sum.val >= 10)
                {
                    overflow = 1;
                    sum.val %= 10;
                }

                if ((l1 != null && l1.next != null) ||
                    (l2 != null && l2.next != null))
                {
                    sum = sum.next = new ListNode(overflow);
                    overflow = 0;
                }

                if (l1 != null)
                {
                    l1 = l1.next;
                }

                if (l2 != null)
                {
                    l2 = l2.next;
                }
            }

            if (overflow > 0)
            {
                sum.next = new ListNode(1);
            }

            return res;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }

            public override string ToString()
            {
                var res = new StringBuilder();

                var current = this;

                res.Append(current.val);

                while (current.next != null)
                {
                    current = current.next;
                    res.Append(current.val);
                }

                var chars = res.ToString().ToCharArray();
                Array.Reverse(chars);
                return new string(chars);
            }
        }
    }
}
