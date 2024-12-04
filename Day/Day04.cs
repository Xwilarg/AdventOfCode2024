using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day
{
    public class Day04
    {
        public void Execute()
        {
            var lines = File.ReadAllLines("data/day04.txt");

            bool LookFor(int progX, int progY, int x, int y)
            {
                string target = "XMAS";

                for (int i = 0; i < target.Length; i++)
                {
                    var py = y + (progY * i);
                    var px = x + (progX * i);
                    if (py < 0 || px < 0 || py >= lines.Length || px >= lines[y].Length) return false;

                    if (target[i] != lines[py][px]) return false;
                }

                return true;
            }

            int count = 0;
            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    for (int ty = -1; ty <= 1; ty++)
                    {
                        for (int tx = -1; tx <= 1; tx++)
                        {
                            if (tx != 0 || ty != 0)
                            {
                                if (LookFor(tx, ty, x, y)) count++;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}