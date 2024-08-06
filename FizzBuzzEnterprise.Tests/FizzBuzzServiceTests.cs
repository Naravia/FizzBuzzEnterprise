using FizzBuzzEnterprise.Services.FizzBuzz;

namespace FizzBuzzEnterprise.Tests;

public class FizzBuzzServiceTests
{
    [Test]
    public void Can_Instantiate_FizzBuzzService()
    {
        Assert.DoesNotThrow(() => { _ = new FizzBuzzService(); });
    }

    [TestCase(1, false, false)]
    [TestCase(3, true, false)]
    [TestCase(5, false, true)]
    [TestCase(10, false, true)]
    [TestCase(15, true, true)]
    public void FizzBuzzService_EvaluatesTo_CorrectResult(int number, bool fizz, bool buzz)
    {
        var service = new FizzBuzzService();
        var result = service.EvaluateFizzBuzz(number);
        Assert.That(result.Fizz, Is.EqualTo(fizz));
        Assert.That(result.Buzz, Is.EqualTo(buzz));
    }
}