using System.ComponentModel.Design;
using FizzBuzzEnterprise.Extensions;
using FizzBuzzEnterprise.Services.FizzBuzz;
using FizzBuzzEnterprise.Services.FizzBuzzPrinter;
using FizzBuzzEnterprise.Services.OutputWriter;

// This makes the assumption that the "use Reflection" instruction indicates you want me to demonstrate
// I understand how to resolve types "manually" using reflection.
// In a real-world application, I would pull in a DI container like Autofac, SimpleInjector, or Microsoft.Extensions.DependencyInjection.
var serviceContainer = new ServiceContainer();
serviceContainer.RegisterService<IFizzBuzzService, FizzBuzzService>();
serviceContainer.RegisterService<IFizzBuzzPrinterService, FizzBuzzPrinterService>();
serviceContainer.RegisterService<IOutputWriterService, ConsoleWriterService>();

if (serviceContainer.GetService(typeof(IFizzBuzzPrinterService))
    is not IFizzBuzzPrinterService fizzBuzzPrinter1)
{
    throw new InvalidOperationException("Failed to resolve IFizzBuzzPrinterService.");
}

for (var i = 1; i <= 100; i++)
{
    fizzBuzzPrinter1.EvaluateFizzBuzz(i);
}