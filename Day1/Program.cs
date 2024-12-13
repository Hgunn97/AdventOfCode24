using CommonServices;
using Microsoft.Extensions.DependencyInjection;

namespace Day1;

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
        services.AddCommonServices();
            
        services.AddTransient<App>();
    }
}