using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FirstApp.Interfaces;
using Fibonacci;
using Microsoft.Extensions.Logging;

namespace FirstApp
{
    public class Startup
    {
        IConfigurationRoot Configuration { get; }
        public Startup()
        {
            var currentDirectory = Directory.GetCurrentDirectory();

            var builder = new ConfigurationBuilder()
                .SetBasePath(currentDirectory)
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            NLog.LogManager.LoadConfiguration("nlog.config");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
            services.AddLogging((builder) => builder.SetMinimumLevel(LogLevel.Trace));

            services.AddSingleton<IFibonacciCalculator, FibonacciCalculator>();

            services.AddTransient<IRestMessageSender, RestMessageSender>();
            services.AddSingleton<IRabbitReciever, RabbitReciever>();
            services.AddSingleton(BusBuilder.CreateMessageBus());

            services.AddTransient<ConsoleApp>();
        }
    }
}
