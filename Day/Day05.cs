namespace AdventOfCode2024.Day
{
    public class Day05
    {
        public void Execute()
        {
            var lines = File.ReadAllText("data/day05.txt").Trim().Split("\n\n");
            var instructions = lines[0].Split('\n');
            var books = lines[1].Split('\n');

            int count = 0;

            foreach (var b in books)
            {
                var pages = b.Split(',');
                if (Enumerable.Range(0, pages.Length - 1).All(i => !instructions.Contains($"{pages[i + 1]}|{pages[i]}"))) count += int.Parse(pages[pages.Length / 2]);
            }

            Console.WriteLine(count);
        }
    }
}