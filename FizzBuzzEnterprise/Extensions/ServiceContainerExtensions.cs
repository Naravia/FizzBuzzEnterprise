using System.ComponentModel.Design;

namespace FizzBuzzEnterprise.Extensions;

public static class ServiceContainerExtensions
{
    public static void RegisterService<TService, TImplementation>(this ServiceContainer container)
        where TService : class
        where TImplementation : class, TService
    {
        container.AddService(typeof(TService), (c, t) =>
        {
            var constructors = typeof(TImplementation).GetConstructors();
            if (constructors.Length > 1)
            {
                throw new InvalidOperationException("Cannot resolve service with multiple constructors.");
            }
            
            var constructor = constructors.Single();
            var parameters = constructor.GetParameters();
            var arguments = new object?[parameters.Length];
            for (var i = 0; i < parameters.Length; i++)
            {
                arguments[i] = c.GetService(parameters[i].ParameterType);
            }
            return Activator.CreateInstance(typeof(TImplementation), arguments);
        });
    }
}