using FizzBuzzEnterprise.Services.FizzBuzz;
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
        Assert.DoesNotThrow(() => { _ = new FizzBuzzPrinterService(new FizzBuzzService(), OutputWriter); });
    }

    [TestCase(1, "1")]
    [TestCase(3, "Fizz")]
    [TestCase(5, "Buzz")]
    [TestCase(10, "Buzz")]
    [TestCase(15, "FizzBuzz")]
    public void FizzBuzzPrinterService_EvaluatesAndPrints_CorrectResult(int number, string expectedString)
    {
        var service = new FizzBuzzPrinterService(new FizzBuzzService(), OutputWriter);
        service.EvaluateFizzBuzz(number);

        var mock = Mock.Get(OutputWriter);
        mock.Verify(x => x.Write(expectedString), Times.Once);
    }

    [Test]
    public void FizzBuzzPrinterService_Calls_FizzBuzzService()
    {
        // This test represents a production bugfix, where an issue is reported that the FizzBuzzService is not being called.

        var fizzBuzzService = Mock.Of<IFizzBuzzService>(x => x.EvaluateFizzBuzz(5) == new FizzBuzzResult(false, true));
        var service = new FizzBuzzPrinterService(fizzBuzzService, OutputWriter);
        service.EvaluateFizzBuzz(5);

        var mock = Mock.Get(fizzBuzzService);
        // We expect the FizzBuzzService to be called once with the number 5.
        mock.Verify(x => x.EvaluateFizzBuzz(5), Times.Once);
    }
}