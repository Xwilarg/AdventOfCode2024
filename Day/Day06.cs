namespace AdventOfCode2024.Day
{
    public class Day06
    {
        private class Vector2
        {
            public int X, Y;
        }

        public void Execute()
        {
            var lines = File.ReadAllLines("data/day06.txt");
            var map = new char[lines[0].Length, lines.Length];

            Vector2 startPoint = null;
            Vector2 player = null;
            int walkCount = 0;

            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < lines.Length; x++)
                {
                    var c = lines[y][x];
                    if (c == '^')
                    {
                        player = new() { X = x, Y = y };
                        startPoint = new() { X = x, Y = y };
                        map[x, y] = '.';
                    }
                    else
                    {
                        map[x, y] = c;
                    }
                }
            }

            bool IsOob(int x, int y)
                => x < 0 || y < 0 || y >= lines.Length || x >= lines[y].Length;

            Vector2[] directions = [new() { X = 0, Y = -1 }, new() { X = 1, Y = 0 }, new() { X = 0, Y = 1 }, new() { X = -1, Y = 0 }];
            int dirIndex = 0;
            do
            {
                var d = directions[dirIndex];
                char next = map[player.X + d.X, player.Y + d.Y];
                while (next == '#')
                {
                    dirIndex++;
                    if (dirIndex == directions.Length) dirIndex = 0;
                    d = directions[dirIndex];
                    next = map[player.X + d.X, player.Y + d.Y];
                }

                if (map[player.X, player.Y] != 'X')
                {
                    map[player.X, player.Y] = 'X';
                    walkCount++;
                }

                player.X += d.X;
                player.Y += d.Y;

                /*
                for (int y = 0; y < lines.Length; y++)
                {
                    for (int x = 0; x < lines.Length; x++)
                    {
                        Console.Write(map[x, y]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine();
                */

            } while (
                /* player.X != startPoint.X || player.Y != startPoint.Y || dirIndex != 0 */ // Check for loops, but not needed as for now
                !IsOob(player.X + directions[dirIndex].X, player.Y + directions[dirIndex].Y)
            );
            walkCount++;

            Console.WriteLine(walkCount);
        }
    }
}