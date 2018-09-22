using System;
using Microsoft.Extensions.DependencyInjection;

namespace FirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();

            Startup startup = new Startup();
            startup.ConfigureServices(services);

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            serviceProvider.GetService<ConsoleApp>().Run();
        }
    }
}
