namespace leetcode
{
    class Assignment0374
    {
        static readonly int _answer = 2147483647;



        public static void Run()
        {
            var res = new Assignment0374().GuessNumber(2147483647);
            System.Console.WriteLine($"Answer: {res}");
        }

        public int GuessNumber(int n)
        {
            var min = 1;
            var max = n;
            var mid = min + (max - min) / 2;

            var res = guess(mid);

            while (res != 0)
            {
                if (res == 1) // too low
                {
                    min = mid + 1;
                }
                else if (res == -1) // too high
                {
                    max = mid - 1;
                }

                // this can cause int overflow without the long...
                // mid = (int) (((long)max + (long)min + 1) / 2);

                // better go for this
                mid = min + (max - min) / 2;
                res = guess(mid);
            }

            return mid;
        }

        // Fake api call.
        int guess(int num)
        {
            var res = _answer - num;

            if (res == 0)
            {
                return 0;
            }
            else if (res < 0)
            {
                return -1;
            }

            return 1;
        }
    }
}
