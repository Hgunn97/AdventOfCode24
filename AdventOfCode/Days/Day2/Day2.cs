using AdventOfCode.Interfaces;

namespace AdventOfCode.Days.Day2;

public class Day2(IFileService fileService): IDay2
{
    public void ExecuteDay2()
    {
        var puzzleInput = fileService.ReadLines("./Days/Day2/puzzleInputDay2.txt");
        var input = GeneratePuzzleReports(puzzleInput);

        var part1 = ValidateReports(input);
        Console.WriteLine($"Valid reports: {part1}");
        
        var part2 = ValidateReportsWithDampener(input);
        Console.WriteLine($"Valid reports: {part2}");
    }
    
    private Dictionary<string, List<int>> GeneratePuzzleReports(IEnumerable<string> puzzleInput)
    {
        var dictionary = new Dictionary<string, List<int>>();

        var rNumber = 1;
        
        foreach (var line in puzzleInput)
        {
            var split = line.Split(" ").ToList();
            var intList = split.Select(int.Parse).ToList();
            
            dictionary.Add($"Report {rNumber}", intList);
            
            rNumber++;
        }
        
        return dictionary;
    }

    private bool IsValid(List<int> report)
    {
        var isIncreasing = true;
        var isDecreasing = true;

        for (int i = 0; i < report.Count; i++)
        {
            if (i == report.Count - 1)
            {
                break;
            }
                
            var currentNumber = report[i];
            var nextNumber = report[i + 1];
            var difference = nextNumber - currentNumber;

            if (difference == 0 || difference > 3 || difference < -3)
            {
                Console.WriteLine($"Report is invalid");
                return false;
            }

            if (difference > 0) isDecreasing = false;
            if (difference < 0) isIncreasing = false;
        }

        if (isIncreasing || isDecreasing)
        {
            Console.WriteLine($"Report is valid");
            return true;
        }

        Console.WriteLine($"Report is not valid");
        return false;
    }
    
    private int ValidateReports(Dictionary<string, List<int>> input)
    {
        var valid = 0;

        foreach (var kvp in input)
        {
            Console.WriteLine($"Checking {kvp.Key}");

            var numbers = kvp.Value;

            if (IsValid(numbers))
                valid++;
        }

        return valid;
    }

    private int ValidateReportsWithDampener(Dictionary<string, List<int>> input)
    {
        var valid = 0;

        foreach (var kvp in input)
        {
            Console.WriteLine($"Checking {kvp.Key}");
            
            var numbers = kvp.Value;

            if (IsValid(numbers))
            {
                Console.WriteLine($"Report is valid without dampener");
                valid++;
                continue;
            }

            Console.WriteLine($"Checking report is valid with dampener");
                
            for (int i = 0; i < numbers.Count; i++)
            {
                var modifiedNumbers = new List<int>(numbers);
                modifiedNumbers.RemoveAt(i);

                if (IsValid(modifiedNumbers))
                {
                    valid++;
                    Console.WriteLine($"{kvp.Key} is valid with dampener (removed level {numbers[i]}).");
                    break;
                }
            }

        }
        return valid;
    }
}