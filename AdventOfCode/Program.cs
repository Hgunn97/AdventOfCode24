using AdventOfCode.Days;
using AdventOfCode.Days.Day1;
using AdventOfCode.Days.Day2;
using AdventOfCode.Days.Day3;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode;

public class Program
{
    public static void Main(string[] args)
    {
        IServiceCollection serviceCollection = new ServiceCollection();
        
        ConfigureServices(serviceCollection);
        
        var serviceProvider = serviceCollection.BuildServiceProvider();
        serviceProvider.GetService<App>()!.Run();
    }
    
    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddServices();
        
        services.AddTransient<IDay1, Day1>();
        services.AddTransient<IDay2, Day2>();
        services.AddTransient<IDay3, Day3>();
        services.AddTransient<App>();
    }
}