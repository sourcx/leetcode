
using System.Text;

namespace leetcode
{
    class Assignment0876
    {
        public static void Run()
        {
            // Input: head = [1,2,3,4,5]
            // Output: [3,4,5]
            // Explanation: The middle node of the list is node 3.

            // Input: head = [1,2,3,4,5,6]
            // Output: [4,5,6]
            // Explanation: Since the list has two middle nodes with values 3 and 4, we return the second one.

            var node = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, new ListNode(6))))));
            var res = (new Assignment0876()).MiddleNode(node);
            System.Console.WriteLine($"{res}");
        }

        public ListNode MiddleNode(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;

            while (fast.next != null && fast.next.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }

            if (fast.next != null)
            {
                slow = slow.next;
            }

            return slow;
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
