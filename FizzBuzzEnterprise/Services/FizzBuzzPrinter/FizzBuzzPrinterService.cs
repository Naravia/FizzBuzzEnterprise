using System.Text;
using FizzBuzzEnterprise.Services.FizzBuzz;
using FizzBuzzEnterprise.Services.OutputWriter;

namespace FizzBuzzEnterprise.Services.FizzBuzzPrinter;

public class FizzBuzzPrinterService : IFizzBuzzPrinterService
{
    private readonly IFizzBuzzService _fizzBuzzService;
    private readonly IOutputWriterService _outputWriter;
    private readonly StringBuilder _output = new("FizzBuzz".Length);

    public FizzBuzzPrinterService(IFizzBuzzService fizzBuzzService, IOutputWriterService outputWriter)
    {
        _fizzBuzzService = fizzBuzzService;
        _outputWriter = outputWriter;
    }
    
    public void EvaluateFizzBuzz(int number)
    {
        _output.Clear();
        if (number % 3 == 0)
        {
            _output.Append("Fizz");
        }

        if (number % 5 == 0)
        {
            _output.Append("Buzz");
        }
        
        // This will write an empty string if neither condition is met.
        // This is a deliberate design decision made for the following reasons:
        //      1. It makes it easy to detect that "no output" was written. This is useful for testing.
        //      2. It allows for concatenating empty results e.g. for display via table.
        //      3. If this behaviour is not desired, it can easily be filtered by the caller.
        _outputWriter.Write(_output.ToString());
    }
}