using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SecondApp.Interfaces;
using SecondApp.Utilits;
using EasyNetQ;
using Fibonacci;

namespace SecondApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IFibonacciCalculator, FibonacciCalculator>();
            services.AddTransient<IRequestHandler, RequestHandler>();
            services.AddTransient<IRabbitSender, RabbitSender>();
            services.AddSingleton<IBus>(provider => {
                var rabbitAddress = Configuration["Host"];
                return RabbitHutch.CreateBus(rabbitAddress);
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
