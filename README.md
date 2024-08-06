# FizzBuzzEnterprise

## This repository is not interesting to most people. It is part of an unrelated programming exercise.

This demonstrates my attempt to solve the "FizzBuzz" problem in an enterprise-like manner.

## Notes

I have left comments where I felt appropriate.

I wanted to also include an `IServiceCollection` solution, but found myself running short on time. Instead, I have included a comment indicating that `IServiceCollection` is how I would solve that particular issue in a real-world application.

I deliberately architected the application under the false requirement that numbers which do not match "Fizz" or "Buzz" would initially print a blank string. This allowed me to then demonstrate at the end how a changing requirement could be applied via unit tests, as well as notes on what I would not change.
