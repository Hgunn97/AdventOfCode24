using AdventOfCode.Interfaces;

namespace AdventOfCode.Days.Day1;

public class Day1(IFileService fileService): IDay1
{
    public void ExecuteDay1()
    {
        var puzzleInput = fileService.ReadLines("./Days/Day1/puzzleInputDay1.txt");
        var input = GeneratePuzzleInputLists(puzzleInput);
        
        Console.WriteLine(PartOne(input));
        Console.WriteLine(PartTwo(input));
    }
    
    private Dictionary<string, List<int>> GeneratePuzzleInputLists(IEnumerable<string> puzzleInput)
    {
        var dictionary = new Dictionary<string, List<int>>
        {
            { "ListOne", [] },
            { "ListTwo", [] }
        };

        foreach (var line in puzzleInput)
        {
            var split = line.Split("  ");
            dictionary["ListOne"].Add(int.Parse(split[0]));
            dictionary["ListTwo"].Add(int.Parse(split[1]));
        }
        
        return dictionary;
    }

    private int PartOne(Dictionary<string, List<int>> puzzleInput)
    {
        var listOne = puzzleInput["ListOne"];
        var listTwo = puzzleInput["ListTwo"];
        
        listOne.Sort();
        listTwo.Sort();
        
        return listOne.Select((x, i) => Math.Abs(x - listTwo[i])).Sum();
    }

    private int PartTwo(Dictionary<string, List<int>> puzzleInput)
    {
        var listOne = puzzleInput["ListOne"];
        var listTwo = puzzleInput["ListTwo"];

        var similarityScore = 0;
        
        foreach (var item in listOne)
        {
            var countOfItemInList = listTwo.Count(x => x.Equals(item));
            
            similarityScore += item * countOfItemInList;
        }

        return similarityScore;
    }
}