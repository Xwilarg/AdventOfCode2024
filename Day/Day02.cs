using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day
{
    public class Day02
    {
        private bool DoesFillCondition(int a, int b, bool order)
        {
            return a != b && Math.Abs(a - b) <= 3 && (order ? (a > b) : (a < b));
        }

        private bool CheckOrderWithSafestate(int[] tmp, bool order, int incr)
        {
            var nbs = tmp.ToList();
            var v1 = false;
            for (int i = 0; i < nbs.Count - 1; i++)
            {
                if (!DoesFillCondition(nbs[i], nbs[i + 1], order))
                {
                    if (!v1)
                    {
                        v1 = true;
                        nbs.RemoveAt(i + incr);
                        i = -1;
                    }
                    else return false;
                }
            }
            return true;
        }

        public void Execute()
        {
            var day2 = File.ReadAllLines("data/day02.txt");
            int countD1 = 0;
            int countD2 = 0;
            foreach (var l in day2)
            {
                var nbs = l.Split(' ').Select(int.Parse).ToArray();

                // Check diff
                var nbDiffOk = Enumerable.Range(0, nbs.Length - 1).All(i => nbs[i] != nbs[i + 1] && Math.Abs(nbs[i] - nbs[i + 1]) <= 3);

                if (nbDiffOk && (Enumerable.SequenceEqual(nbs, nbs.Order()) || Enumerable.SequenceEqual(nbs, nbs.OrderByDescending(x => x)))) countD1++;

                if (CheckOrderWithSafestate(nbs, true, 0) || CheckOrderWithSafestate(nbs, true, 1) || CheckOrderWithSafestate(nbs, false, 0) || CheckOrderWithSafestate(nbs, false, 1)) countD2++;
            }

            Console.WriteLine(countD1);
            Console.WriteLine(countD2);
        }
    }
}
