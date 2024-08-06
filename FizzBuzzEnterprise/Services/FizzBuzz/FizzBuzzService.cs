namespace FizzBuzzEnterprise.Services.FizzBuzz;

public class FizzBuzzService : IFizzBuzzService
{
    public FizzBuzzResult EvaluateFizzBuzz(int number)
    {
        return new FizzBuzzResult(number % 3 == 0, number % 5 == 0);
    }
}