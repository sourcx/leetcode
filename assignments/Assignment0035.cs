namespace leetcode
{
    class Assignment0035
    {
        public static void Run()
        {
            var nums = new[] { 1, 3, 5, 6 };
            var target = 10;
            var res = new Assignment0035().SearchInsert(nums, target);
            System.Console.WriteLine($"Answer: {res}.");
        }

        public int SearchInsert(int[] nums, int target)
        {
            int min = 0;
            int max = nums.Length - 1;

            int mid = min + (max - min) / 2;

            while (min < max)
            {
                if (target == nums[mid])
                {
                    return mid;
                }
                else if (target > nums[mid])
                {
                    min = mid + 1;
                }
                else
                {
                    max = mid;
                }
                mid = min + (max - min) / 2;
            }

            if (target > nums[mid])
            {
                return mid + 1;
            }

            return mid;
        }
    }
}
