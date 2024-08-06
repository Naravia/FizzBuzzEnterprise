using System.ComponentModel.Design;
using FizzBuzzEnterprise.Services.FizzBuzz;

var serviceContainer = new ServiceContainer();
serviceContainer.AddService(typeof(IFizzBuzzService), new FizzBuzzService());