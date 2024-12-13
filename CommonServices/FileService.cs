namespace CommonServices;

public class FileService: IFileService
{
    public IEnumerable<string> ReadLines(string path)
    {
        return File.ReadLines(path);
    }
}