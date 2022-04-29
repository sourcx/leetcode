namespace leetcode
{
    class Assignment0383
    {
        public static void Run()
        {
            var ransomNote = "abcc";
            var magazine = "xacbdce";
            var res = new Assignment0383().CanConstruct(ransomNote, magazine);
            System.Console.WriteLine($"Answer: {res}.");
        }

        public bool CanConstruct(string ransomNote, string magazine)
        {
            var dict = new Dictionary<char, int>();

            foreach (var c in magazine)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c] += 1;
                }
                else
                {
                    dict[c] = 1;
                }
            }

            foreach (var c in ransomNote)
            {
                if (dict.ContainsKey(c) && dict[c] > 0)
                {
                    dict[c] -= 1;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
