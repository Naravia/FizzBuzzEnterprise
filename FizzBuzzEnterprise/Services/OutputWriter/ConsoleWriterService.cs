﻿namespace FizzBuzzEnterprise.Services.OutputWriter;

public class ConsoleWriterService : IOutputWriterService
{
    public void Write(string output)
    {
        // This method is deliberately untested.
        // This represents a real-world scenario where we would not test code that interacts with external dependencies.
        // In our case, the logic has been extracted to the FizzBuzzPrinterService, which is tested.
        
        // Another example of this would be a class that interacts with a database - the logic would be extracted
        // into a separate class that can be tested, and the database interaction would be left untested.
        
        // If we wished to test this method, we would do so via integration tests.
        
        // If we're called with no output, we don't want to write anything.
        // Although requirements have changed, we can safely leave this code in place.
        // We don't want to make more changes than are necessary, and if this becomes an issue in future
        // this should be surfaced via tests before being altered, rather than silently changing unrelated
        // parts of the system.
        if (output == string.Empty)
        {
            return;
        }
        Console.WriteLine(output);
    }
}