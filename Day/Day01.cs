﻿using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day
{
    public class Day01
    {
        public void Execute()
        {
            List<int> l1 = new();
            List<int> l2 = new();

            foreach (var d in File.ReadAllLines("data/day01.txt"))
            {
                var m = Regex.Match(d, "([0-9]+) +([0-9]+)");

                l1.Add(int.Parse(m.Groups[1].Value));
                l2.Add(int.Parse(m.Groups[2].Value));
            }

            l1 = [.. l1.Order()];
            l2 = [.. l2.Order()];

            var res = Enumerable.Range(0, l1.Count).Sum(i => Math.Abs(l1[i] - l2[i]));

            Console.WriteLine(res);

            var res2 = Enumerable.Range(0, l1.Count).Sum(i => l1[i] * l2.Count(x => x == l1[i]));

            Console.WriteLine(res2);
        }
    }
}
