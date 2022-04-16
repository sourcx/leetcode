using System.Diagnostics;

namespace leetcode
{
    class Assignment0015
    {
        static int[] _input = new int[] { 12,5,-12,4,-11,11,2,7 };

         public static void Run()
        {
            var sw = new Stopwatch();
            sw.Start();
            var triplets = new Assignment0015().ThreeSumSlow(_input);
            sw.Stop();
            System.Console.WriteLine($"Got {triplets.Count} triplets in {sw.ElapsedMilliseconds}ms");

            sw.Reset();
            sw.Start();
            triplets = new Assignment0015().ThreeSumFaster(_input);
            sw.Stop();
            System.Console.WriteLine($"Got {triplets.Count} triplets in {sw.ElapsedMilliseconds}ms");

            sw.Reset();
            sw.Start();
            triplets = new Assignment0015().ThreeSum(_input);
            sw.Stop();
            System.Console.WriteLine($"Got {triplets.Count} triplets in {sw.ElapsedMilliseconds}ms");
        }

        // Original version that makes the triplet list unique at the end by iterating over all
        // triplets and adding them to another list if they are not in there yet.
        // This has to search the list n^2 times.
        public IList<IList<int>> ThreeSumSlow(int[] nums)
        {
            var triplets = new List<IList<int>>();

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    for (int k = 0; k < nums.Length; k++)
                    {
                        if (i == k || j == k)
                        {
                            continue;
                        }

                        if (nums[i] + nums[j] + nums[k] == 0)
                        {
                            var triplet = new List<int>() { nums[i], nums[j], nums[k] };
                            triplets.Add(triplet);
                        }
                    }
                }
            }

            var uniqueTriplets = new List<IList<int>>();

            foreach (var triplet in triplets)
            {
                var tripletSet = new HashSet<int>(triplet);

                bool contains = false;
                foreach (var uniqueTriplet in uniqueTriplets)
                {
                    var uniqueTripletSet = new HashSet<int>(uniqueTriplet);
                    if (tripletSet.SetEquals(uniqueTripletSet))
                    {
                        contains = true;
                        continue;
                    }
                }

                if (!contains)
                {
                    uniqueTriplets.Add(triplet);
                }
            }

            return uniqueTriplets;
        }

        // Second attempt runs faster because we use the hashset
        public IList<IList<int>> ThreeSumFaster(int[] nums)
        {
            // use a hashset to store valid triplets
            var triplets = new HashSet<List<int>>(new TripleComparer());

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    for (int k = 0; k < nums.Length; k++)
                    {
                        if (i == k || j == k)
                        {
                            continue;
                        }

                        if (nums[i] + nums[j] + nums[k] == 0)
                        {
                            var triplet = new List<int>() { nums[i], nums[j], nums[k] };
                            triplets.Add(triplet);
                        }
                    }
                }
            }

            var list = new List<IList<int>>();
            foreach (var triplet in triplets)
            {
                list.Add(triplet);
            }

            return list;
        }

        private class TripleComparer : IEqualityComparer<List<int>>
        {
            public bool Equals(List<int> one, List<int> other)
            {
                var setOne = new HashSet<int>(one);
                var setOther = new HashSet<int>(other);

                return setOne.SetEquals(setOther);
            }

            // I'm not 100% sure if this is correct.
            public int GetHashCode(List<int> list)
            {
                return list[0] * list[1] * list[2];
            }
        }

        bool _zerosAdded = false;

        // Third attempt. I have reduced the problem to use only 2 values for comparison.
        // We take all pairs of numbers (i, j) and see if -1(i + j) is in a sorted version of all numbers.
        // If so we have a match for this tuple (e.g. triplet).
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var list = new List<IList<int>>();
            var numsList = new List<int>(nums);
            var allSortedNums = new SortedList<int, int>(nums.Length);
            foreach (var num in new HashSet<int>(nums))
            {
                allSortedNums.Add(num, num);
            }

            // Use a hashset to store valid pairs which are incomplete triplets.
            var tuples = new HashSet<Tuple<int, int>>();

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    // edgecase for zero's (a bit lame)
                    if (nums[i] == 0 && nums[j] == 0)
                    {
                        if (!_zerosAdded)
                        {
                            if (numsList.Count(n => n == 0) > 2)
                            {
                                tuples.Add(new Tuple<int, int>(0, 0));
                            }
                            _zerosAdded = true;
                        }
                        continue;
                    }

                    var third = (-1 * (nums[i] + nums[j]));

                    if (allSortedNums.ContainsKey(third))
                    {
                        if (third == nums[i])
                        {
                            var indicesOfThird = Enumerable.Range(0, numsList.Count).Where(n => numsList[n] == third).ToList();
                            indicesOfThird.Remove(i);

                            if (indicesOfThird.Count <= 0)
                            {
                                continue;
                            }
                        }

                        if (third == nums[j])
                        {
                            var indicesOfThird = Enumerable.Range(0, numsList.Count).Where(n => numsList[n] == third).ToList();
                            indicesOfThird.Remove(j);

                            if (indicesOfThird.Count <= 0)
                            {
                                continue;
                            }
                        }

                        if (nums[i] < nums[j])
                        {
                            tuples.Add(new Tuple<int, int>(nums[i], nums[j]));
                        }
                        else
                        {
                            tuples.Add(new Tuple<int, int>(nums[j], nums[i]));
                        }
                    }
                }
            }

            var triplets = new HashSet<List<int>>(new TripleComparer());

            foreach (var tuple in tuples)
            {
                triplets.Add(new List<int>() { tuple.Item1, tuple.Item2, (-1 * (tuple.Item1 + tuple.Item2)) });
            }

            foreach (var triplet in triplets)
            {
                list.Add(triplet);
            }

            return list;
        }

        private class TupleComparer : IEqualityComparer<Tuple<int, int>>
        {
            public bool Equals(Tuple<int, int> one, Tuple<int, int> other)
            {
                return (one.Item1 == other.Item1 && one.Item2 == other.Item2) ||
                       (one.Item1 == other.Item2 && one.Item2 == other.Item1);
            }

            // I'm not 100% sure if this is correct.
            public int GetHashCode(Tuple<int, int> t)
            {
                return t.Item1 * t.Item2;
            }
        }
    }
}
