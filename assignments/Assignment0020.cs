using System.Diagnostics;

namespace leetcode
{
    class Assignment0020
    {
        public static void Run()
        {
            var sw = new Stopwatch();
            sw.Start();
            var res = new Assignment0020().IsValid("){");
            sw.Stop();
            System.Console.WriteLine($"Answer: {res}");
        }

        // Your runtime beats 99.93 % of csharp submissions.
        public bool IsValid(string s)
        {
            if (s.Length % 2 != 0)
            {
                return false;
            }

            var stack = new Stack<char>();

            foreach (var c in s)
            {
                if (c == '[' || c == '(' || c == '{')
                {
                    stack.Push(c);
                }
                else if (c == ']')
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }
                    var closing = stack.Pop();
                    if (closing != '[')
                    {
                        return false;
                    }
                }
                else if (c == ')')
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }
                    var closing = stack.Pop();
                    if (closing != '(')
                    {
                        return false;
                    }
                }
                else if (c == '}')
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }
                    var closing = stack.Pop();
                    if (closing != '{')
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return stack.Count == 0;
        }
    }
}
