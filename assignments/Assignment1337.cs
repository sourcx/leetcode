namespace leetcode
{
    class Assignment1337
    {
        public static void Run()
        {
            var mat = new int[][]
            {
                new int[] { 1, 1, 0, 0, 0 },
                new int[] { 1, 1, 1, 1, 0 },
                new int[] { 1, 0, 0, 0, 0 },
                new int[] { 1, 1, 0, 0, 0 },
                new int[] { 1, 1, 1, 1, 1 }
            };
            var k = 3;

            var res = (new Assignment1337()).KWeakestRows(mat, k);
            for (int j = 0; j < res.Length; j++)
            {
                System.Console.Write($"{res[j]} ");
            }
            System.Console.WriteLine("");
        }

        public int[] KWeakestRows(int[][] mat, int k)
        {
            var scores = new Dictionary<int, int>();

            for (int j = 0; j < mat.Length; j++)
            {
                scores[j] = Score(mat[j]);
            }

            var sortedKeys = scores.Keys.OrderBy(key => scores[key]);
            return sortedKeys.Take(k).ToArray();
        }

        private int Score(int[] row)
        {
            int score = 0;

            for (int i = 0; i < row.Length; i++)
            {
                if (row[i] == 1)
                {
                    score += 1;
                }
                else
                {
                    return score;
                }
            }

            return score;
        }
    }
}
