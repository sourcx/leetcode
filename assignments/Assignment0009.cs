namespace leetcode
{
    class Assignment0009
    {
        public static void Run()
        {
            System.Console.WriteLine(new Assignment0009().IsPalindrome(0));
            System.Console.WriteLine(new Assignment0009().IsPalindrome(10));
            System.Console.WriteLine(new Assignment0009().IsPalindrome(111));
            System.Console.WriteLine(new Assignment0009().IsPalindrome(110));
            System.Console.WriteLine(new Assignment0009().IsPalindrome(1001));
            System.Console.WriteLine(new Assignment0009().IsPalindrome(1011));
        }

        public bool IsPalindrome(int x)
        {
            if (x < 0)
            {
                return false;
            }

            var s = x.ToString();
            for (int i = 0; i < (s.Length + 1 / 2); i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
