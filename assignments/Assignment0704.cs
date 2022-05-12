namespace leetcode
{
    // You must write an algorithm with O(log n) runtime complexity.
    class Assignment0704
    {
        public static void Run()
        {
            var nums = new int[] { 9, 10, 11 };
            var target = 9;

            var res = (new Assignment0704()).Search(nums, target);
            System.Console.WriteLine($"{res}");
        }

        // Iteratively search using from and to pointers.
        public int Search(int[] nums, int target)
        {
            int from = 0;
            int to = nums.Length - 1;

            while (from < to)
            {
                int mid = from + ((to - from + 1) / 2);

                if (target < nums[mid])
                {
                    to = mid - 1;
                }
                else
                {
                    from = mid;
                }
            }

            return nums[from] == target ? from : -1;
        }

        // This is a binary search that splits the nums in the middle each time.
        // Do this by using pointer and recursion.
        public int SearchRecursive(int[] nums, int target)
        {
            return Search(nums, target, 0, nums.Length - 1);
        }

        public int Search(int[] nums, int target, int from, int to)
        {
            if (from > to)
            {
                return -1;
            }

            if (from == to)
            {
                if (nums[from] == target)
                {
                    return from;
                }
                else
                {
                    return -1;
                }
            }

            int middleIndex = (from + to) / 2;
            int middleNr = nums[middleIndex];

            if (middleNr == target)
            {
                return middleIndex;
            }
            else if (target < middleNr)
            {
                return Search(nums, target, 0, middleIndex);
            }
            else // if (target > middleNr)
            {
                return Search(nums, target, middleIndex + 1, to);
            }
        }
    }
}
