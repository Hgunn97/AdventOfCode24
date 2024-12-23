namespace AdventOfCode.Interfaces;

public interface IFileService
{
    IEnumerable<string> ReadLines(string path);
    string ReadText(string path);
}