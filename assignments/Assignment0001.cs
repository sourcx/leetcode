namespace leetcode
{
    class Assignment0001
    {
        public static void Run()
        {
            var indices = new Assignment0001().TwoSum(new int[] { 1, 2, 3 }, 4);
            System.Console.WriteLine("Indices: " + string.Join(",", indices));
        }

        public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; ++i)
            {
                for (int j = 1; j < nums.Length; ++j)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }

            return null;
        }
    }
}
