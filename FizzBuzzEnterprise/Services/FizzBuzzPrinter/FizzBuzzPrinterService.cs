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
        var result = _fizzBuzzService.EvaluateFizzBuzz(number);
        if (result.Fizz)
        {
            _output.Append("Fizz");
        }

        if (result.Buzz)
        {
            _output.Append("Buzz");
        }
        
        if (!(result.Fizz || result.Buzz))
        {
            _output.Append(number.ToString());
        }
        
        // The comment that was previously here has been removed.
        // It is no longer relevant to the current requirements, but can be restored via version control if needed.
        // This means the comment is always in sync with the relevant version of the code.
        _outputWriter.Write(_output.ToString());
    }
}