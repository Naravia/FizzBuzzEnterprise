using FizzBuzzEnterprise.Services.OutputWriter;

namespace FizzBuzzEnterprise.Services.FizzBuzzPrinter;

public class FizzBuzzPrinterService : IFizzBuzzPrinterService
{
    private readonly IOutputWriterService _outputWriter;

    public FizzBuzzPrinterService(IOutputWriterService outputWriter)
    {
        _outputWriter = outputWriter;
    }
    
    public void EvaluateFizzBuzz(int number)
    {
        throw new NotImplementedException();
    }
}