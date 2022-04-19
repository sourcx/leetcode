namespace leetcode
{
    class Assignment0206
    {
        public static void Run()
        {
            var node = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4))));
            var res = new Assignment0206().ReverseList(node);
            System.Console.WriteLine($"Answer: {res}.");
        }

        public ListNode ReverseList(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            var tail = new ListNode(head.val);

            while (head.next != null)
            {
                var newNode = new ListNode(head.next.val);
                newNode.next = tail;
                tail = newNode;
                head = head.next;
            }

            return tail;
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
