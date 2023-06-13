// See https://aka.ms/new-console-template for more information
using ConsoleApp_DepInjectionDemo;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using System.Runtime.CompilerServices;

public class Program
{
    private static void Main(string[] args)
    {
        IHost host = CreateHost();
        NumberWorker worker = ActivatorUtilities.CreateInstance<NumberWorker>(host.Services);
        worker.PrintNumber();
    }

    private static IHost CreateHost()
    {
        return Host.CreateDefaultBuilder()
          .ConfigureServices((context, services) =>
          {
              services.AddSingleton<INumberRepository, NumberRepository>();
              services.AddSingleton<INumberService, NumberService>();
              services.Configure<NumberConfig>(context.Configuration.GetSection("Number"));
          })
          .UseSerilog((context, services, configuration) => configuration
            .ReadFrom.Configuration(context.Configuration)
            .ReadFrom.Services(services)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.File($"report-{DateTimeOffset.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss")}.txt", restrictedToMinimumLevel: LogEventLevel.Warning)
          )
          .Build();
    }
}