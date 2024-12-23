using System.Text.RegularExpressions;
using AdventOfCode.Interfaces;

namespace AdventOfCode.Days.Day3;

public class Day3(IFileService fileService): IDay3
{
    public void ExecuteDay3()
    {
        Console.WriteLine("");
        Console.WriteLine("--- Day 3 ---");
        var puzzleInput = fileService.ReadText("./Days/Day3/puzzleInputDay3.txt");
        
        var part1 = Part1(puzzleInput);
        Console.WriteLine($"Part 1: {part1}");
        
        var part2 = Part2(puzzleInput);
        Console.WriteLine($"Part 2: {part2}");
    }

    private int Part1(string input)
    {
        string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";
        var matches = Regex.Matches(input, pattern);
        
        var sum = 0;

        foreach (Match match in matches)
        {
            int x = int.Parse(match.Groups[1].Value);
            int y = int.Parse(match.Groups[2].Value);
            sum += x * y;
        }
        
        return sum;
    }

    private int Part2(string input)
    {
        string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";
        string doPattern = @"do\(\)";
        string dontPattern = @"don't\(\)";
        
        bool isEnabled = true;
        int sum = 0;
        
        int position = 0;

        while (position < input.Length)
        {
            // Check dont match instruction
            var dontMatches = Regex.Match(input.Substring(position), dontPattern);
            if (dontMatches.Success && dontMatches.Index == 0)
            {
                isEnabled = false;
                position += dontMatches.Length;
                continue;
            }
            
            // Check do match
            var doMatches = Regex.Match(input.Substring(position), doPattern);
            if (doMatches.Success && doMatches.Index == 0)
            {
                isEnabled = true;
                position += doMatches.Length;
                continue;
            }
            
            // Check sum
            var match = Regex.Match(input.Substring(position), pattern);
            if (match.Success && match.Index == 0)
            {
                if (isEnabled)
                {
                    int x = int.Parse(match.Groups[1].Value);
                    int y = int.Parse(match.Groups[2].Value);
                    sum += x * y;
                }
                position += match.Length;
                continue;
            }

            position++;
        }
        
        return sum;
    }
}