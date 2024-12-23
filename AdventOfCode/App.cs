using AdventOfCode.Days;
using AdventOfCode.Days.Day1;
using AdventOfCode.Days.Day2;
using AdventOfCode.Days.Day3;
using AdventOfCode.Interfaces;

namespace AdventOfCode;

public class App(IFileService fileService, IDay1 day1, IDay2 day2, IDay3 day3)
{
    public void Run()
    {
        day1.ExecuteDay1();
        day2.ExecuteDay2();
        day3.ExecuteDay3();
    }
}