using System.Diagnostics;

namespace leetcode
{
    class Assignment0032
    {
        public static void Run()
        {
            var sw = new Stopwatch();
            sw.Start();
            var res = new Assignment0032().LongestValidParentheses("()(()"); // 2
            sw.Stop();
            System.Console.WriteLine($"Answer: {res} in {sw.ElapsedMilliseconds}ms");
        }

        public int LongestValidParentheses(string s)
        {
            var stack = new Stack<int>();
            stack.Push(-1); // initialized as [)]
            var maxLength = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i); // [)(...(], where ( can be 1 or more
                }
                else
                {
                    stack.Pop();
                    if (stack.Count == 0)
                    {
                        stack.Push(i); // [)]
                    }
                    else
                    {
                        maxLength = Math.Max(maxLength, i - stack.Peek()); // [)(..(], where ( can be 0 or more
                    }
                }
            }

            return maxLength;
        }
    }
}
