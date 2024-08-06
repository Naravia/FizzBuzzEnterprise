using FizzBuzzEnterprise.Services.FizzBuzzPrinter;

namespace FizzBuzzEnterprise.Tests;

public class FizzBuzzPrinterServiceTests
{
    [Test]
    public void Can_Instantiate_FizzBuzzPrinterService()
    {
        Assert.DoesNotThrow(() => { _ = new FizzBuzzPrinterService(); });
    }
    
    [TestCase(1, "")]
    [TestCase(3, "Fizz")]
    [TestCase(5, "Buzz")]
    [TestCase(10, "Buzz")]
    [TestCase(15, "FizzBuzz")]
    public void FizzBuzzPrinterService_EvaluatesAndPrints_CorrectResult(int number, string expectedString)
    {
        var service = new FizzBuzzPrinterService();
        service.EvaluateFizzBuzz(number);
        
        // At this point, we have no way of asserting the output of the console.
        Assert.Fail("Test is incomplete.");
    }
}