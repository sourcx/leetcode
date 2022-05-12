namespace leetcode
{
    class Assignment1672
    {
        public static void Run()
        {
            var accounts = new int[][]
            {
                // new int[] { 1, 1, 0, 0, 0 },
                // new int[] { 1, 1, 1, 1, 0 },
                // new int[] { 1, 0, 0, 0, 0 },
                new int[] { 2, 8, 7 },
                new int[] { 7, 1, 3 },
                new int[] { 1, 9, 5 }
            };

            var res = (new Assignment1672()).MaximumWealth(accounts);
            System.Console.WriteLine($"{res}");
        }

        public int MaximumWealth(int[][] accounts)
        {
            var maxWealth = int.MinValue;

            for (int j = 0; j < accounts.Length; j++)
            {
                var wealth = Wealth(accounts[j]);
                if (wealth > maxWealth)
                {
                    maxWealth = wealth;
                }
            }

            return maxWealth;
        }

        private int Wealth(int[] row)
        {
            int score = 0;

            for (int i = 0; i < row.Length; i++)
            {
                score += row[i];
            }

            return score;
        }
    }
}
