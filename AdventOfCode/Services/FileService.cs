﻿using AdventOfCode.Interfaces;

namespace AdventOfCode.Services;

public class FileService: IFileService
{
    public IEnumerable<string> ReadLines(string path)
    {
        return File.ReadLines(path);
    }

    public string ReadText(string path)
    {
        return File.ReadAllText(path);
    }
}