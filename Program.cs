// See https://aka.ms/new-console-template for more information
using DITutorial;
using DITutorial.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args).ConfigureServices((_, services) =>
    services.AddTransient<ITransientOperation, DefaultOperation>()
    .AddScoped<IScopedOperation, DefaultOperation>()
    .AddSingleton<ISingletonOperation, DefaultOperation>()
    .AddTransient<OperationLogger>()).Build();

ExemplifyScopeing(host.Services, "Scope 1");
ExemplifyScopeing(host.Services, "Scope 2");

void ExemplifyScopeing(IServiceProvider services, string scope)
{
    using IServiceScope serviceScope = services.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;

    OperationLogger logger = provider.GetRequiredService<OperationLogger>();
    logger.LogOperations($"{scope}-Call 1 .GetRequiredService<OperationLogger>()");

    Console.WriteLine("...");

    logger = provider.GetRequiredService<OperationLogger>();
    logger.LogOperations($"{scope}-Call 2 .GetRequiredService<OperationLogger>()");

    Console.WriteLine();
}