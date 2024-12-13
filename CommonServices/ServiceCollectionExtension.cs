using Microsoft.Extensions.DependencyInjection;

namespace CommonServices;

public static class ServiceCollectionExtension
{
    public static void AddCommonServices(this IServiceCollection services)
    {
        services.AddTransient<IFileService, FileService>();
    }
}