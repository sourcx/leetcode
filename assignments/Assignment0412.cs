using System.Text;

namespace leetcode
{
    class Assignment0412
    {
        public static void Run()
        {
            var res = new Assignment0412().FizzBuzz(15);
            foreach (var s in res)
            {
                System.Console.WriteLine($"Answer: {s}.");
            }
        }

        public IList<string> FizzBuzz(int n)
        {
            var list = new List<string>();

            for (int i = 1; i <= n; i++)
            {
                var res = new StringBuilder();

                if (i % 3 == 0)
                {
                    res.Append("Fizz");
                }

                if (i % 5 == 0)
                {
                    res.Append("Buzz");
                }

                if (res.Length == 0)
                {
                    list.Add($"{i}");
                }
                else
                {
                    list.Add(res.ToString());
                }
            }

            return list;
        }
    }
}
