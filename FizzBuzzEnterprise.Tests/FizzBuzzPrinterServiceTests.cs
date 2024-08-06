using FizzBuzzEnterprise.Services.FizzBuzzPrinter;
using FizzBuzzEnterprise.Services.OutputWriter;
using Moq;

namespace FizzBuzzEnterprise.Tests;

public class FizzBuzzPrinterServiceTests
{
    private IOutputWriterService? _outputWriter;
    // We know this will always be set via the SetUp method.
    private IOutputWriterService OutputWriter => _outputWriter!;

    [SetUp]
    public void Setup()
    {
        // It's a bit of a stretch to define this here instead of in the individual tests, but 
        // I'm treating this as a dependency whose configuration is not interesting to the tests.
        _outputWriter = Mock.Of<IOutputWriterService>();
    }
    
    [Test]
    public void Can_Instantiate_FizzBuzzPrinterService()
    {
        Assert.DoesNotThrow(() => { _ = new FizzBuzzPrinterService(OutputWriter); });
    }
    
    [TestCase(1, "")]
    [TestCase(3, "Fizz")]
    [TestCase(5, "Buzz")]
    [TestCase(10, "Buzz")]
    [TestCase(15, "FizzBuzz")]
    public void FizzBuzzPrinterService_EvaluatesAndPrints_CorrectResult(int number, string expectedString)
    {
        var service = new FizzBuzzPrinterService(OutputWriter);
        service.EvaluateFizzBuzz(number);
        
        var mock = Mock.Get(OutputWriter);
        mock.Verify(x => x.Write(expectedString), Times.Once);
    }
}