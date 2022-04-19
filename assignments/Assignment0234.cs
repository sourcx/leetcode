namespace leetcode
{
    class Assignment0234
    {
        public static void Run()
        {
            var node = new ListNode(1, new ListNode(2, new ListNode(2, new ListNode(1))));
            var res = new Assignment0234().IsPalindrome(node);
            System.Console.WriteLine($"Answer: {res}.");
        }

        public bool IsPalindrome(ListNode head)
        {
            var list = new List<int>();

            while (head.next != null)
            {
                list.Add(head.val);
                head = head.next;
            }
            list.Add(head.val);

            for (int i = 0; i < list.Count / 2; i++)
            {
                if (list[i] != list[list.Count - i - 1])
                {
                    return false;
                }
            }

            return true;
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
        }
    }
}
