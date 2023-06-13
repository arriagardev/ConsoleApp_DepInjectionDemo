// See https://aka.ms/new-console-template for more information
using ConsoleApp_DepInjectionDemo;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
          .Build();
    }
}