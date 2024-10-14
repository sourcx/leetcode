
using System.Text;

namespace leetcode
{
    class Assignment0014
    {
        public static void Run()
        {
            System.Console.WriteLine(new Assignment0014().LongestCommonPrefix(new string[] { "flower", "f" }));
        }

        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length < 1)
            {
                return "";
            }

            var first = strs[0];
            var res = new StringBuilder();

            for (int i = 0; i < first.Length; i++)
            {
                for (int j = 0; j < strs.Length; j++)
                {
                    if (i == strs[j].Length)
                    {
                        return res.ToString();
                    }

                    if (strs[j][i] != first[i])
                    {
                        return res.ToString();
                    }
                }

                res.Append(first[i]);
            }

            return res.ToString();
        }
    }
}
