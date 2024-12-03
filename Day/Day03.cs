using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day
{
    public class Day03
    {
        public int GetRes(string text)
            => Regex.Matches(text, "mul\\(([0-9]+),([0-9]+)\\)").Cast<Match>().Sum(x => int.Parse(x.Groups[1].Value) * int.Parse(x.Groups[2].Value));

        public string IgnoreDont(string text)
        {
            bool ignore = false;
            StringBuilder str = new();
            for (int i = 0; i < text.Length; i++)
            {
                if (ignore)
                {
                    if (text[i..].StartsWith("do()"))
                    {
                        i += 4;
                        ignore = false;
                    }
                }
                else
                {
                    if (text[i..].StartsWith("don't()"))
                    {
                        i += 7;
                        ignore = true;
                    }
                }

                if (!ignore) str.Append(text[i]);
            }
            return str.ToString();
        }

        public void Execute()
        {
            var text = File.ReadAllText("data/day03.txt");

            Console.WriteLine(GetRes(text));
            Console.WriteLine(GetRes(IgnoreDont(text)));
        }
    }
}