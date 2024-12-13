namespace CommonServices;

public interface IFileService
{
    IEnumerable<string> ReadLines(string path);
}