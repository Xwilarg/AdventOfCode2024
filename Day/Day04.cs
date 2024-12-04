using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day
{
    public class Day04
    {
        public void Execute()
        {
            var lines = File.ReadAllLines("data/day04.txt");


            bool LookForXMas(int progX, int progY, int x, int y)
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

            bool HasMas(int x, int y)
            {
                if (lines[y][x] != 'A') return false;
                if (x - 1 < 0 || y - 1 < 0 || y + 1 >= lines.Length || x + 1 >= lines[y].Length) return false;
                var ms = "MS";

                return ms.Contains(lines[y - 1][x - 1]) && ms.Contains(lines[y + 1][x + 1]) && lines[y - 1][x - 1] != lines[y + 1][x + 1]
                    && ms.Contains(lines[y - 1][x + 1]) && ms.Contains(lines[y + 1][x - 1]) && lines[y - 1][x + 1] != lines[y + 1][x - 1];
            }

            int countXMas = 0;
            int countMax = 0;
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
                                if (LookForXMas(tx, ty, x, y)) countXMas++;
                            }
                        }
                    }

                    if (HasMas(x, y)) countMax++;
                }
            }

            Console.WriteLine(countXMas);
            Console.WriteLine(countMax);
        }
    }
}