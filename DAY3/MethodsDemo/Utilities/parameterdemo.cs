using System;

namespace Utilities
{
    public class ParametersDemo
    {
        public void Configure(int timeout, bool verbose)
        {
            Console.WriteLine($"Timeout: {timeout}, Verbose: {verbose}");
        }

        public void SetCount(out int count)
        {
            count = 50;
        }
    }
}
