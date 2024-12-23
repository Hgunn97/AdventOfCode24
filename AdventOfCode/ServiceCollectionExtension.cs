using AdventOfCode.Interfaces;
using AdventOfCode.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode;

public static class ServiceCollectionExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IFileService, FileService>();
    }
}