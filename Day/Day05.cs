namespace AdventOfCode2024.Day
{
    public class Day05
    {
        public void Execute()
        {
            var lines = File.ReadAllText("data/day05.txt").Trim().Split("\n\n");
            var instructions = lines[0].Split('\n');
            var books = lines[1].Split('\n');

            int countP1 = 0;
            int countP2 = 0;

            foreach (var b in books)
            {
                var pages = b.Split(',');
                if (Enumerable.Range(0, pages.Length - 1).All(i => !instructions.Contains($"{pages[i + 1]}|{pages[i]}"))) countP1 += int.Parse(pages[pages.Length / 2]);
                else
                {
                    bool isValid;

                    do
                    {
                        isValid = true;
                        for (int i = 0; i < pages.Length - 1; i++)
                        {
                            if (instructions.Contains($"{pages[i + 1]}|{pages[i]}"))
                            {
                                (pages[i + 1], pages[i]) = (pages[i], pages[i + 1]);
                                isValid = false;
                                break;
                            }
                        }
                    } while (!isValid);
                    countP2 += int.Parse(pages[pages.Length / 2]);
                }
            }

            Console.WriteLine(countP1);
            Console.WriteLine(countP2);
        }
    }
}