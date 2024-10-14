namespace leetcode
{
    class Assignment1342
    {
        public static void Run()
        {
            var res = (new Assignment1342()).NumberOfSteps(8);
            System.Console.WriteLine(res);
        }

        // Simple solution is too slow.
        public int NumberOfStepsSlow(int num)
        {
            int steps = 0;

            while (num != 1)
            {
                if (num % 2 == 0)
                {
                    num /= 2;
                }
                else
                {
                    num -= 1;
                }
                steps += 1;
            }

            return steps + 1;
        }

        // Bitwise operator solution.
        // A divide by 2 for an even number is the same as right bitshift with 1.
        // Depending on the last bit, you also have to do the -1 for uneven numbers.
        public int NumberOfSteps(int num)
        {
            if (num == 0)
            {
                return 0;
            }

            int steps = 0;

            while (num != 0)
            {
                var lastBit = num & 1;
                num = num >> 1;

                if (lastBit == 1)
                {
                    steps += 2;
                }
                else
                {
                    steps += 1;
                }
            }

            return steps - 1;
        }
    }
}
