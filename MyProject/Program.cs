using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the upper limit for primes: ");
        if (!int.TryParse(Console.ReadLine(), out int limit) || limit < 2)
        {
            Console.WriteLine("Invalid input. Must be >= 2.");
            return;
        }

        PrimeAnalyzer analyzer = new PrimeAnalyzer(limit);

        analyzer.GeneratePrimes();
        Console.WriteLine($"Generated {analyzer.Primes.Count} primes up to {limit}");

        analyzer.PrintFirstPrimes(10);

        analyzer.AnalyzeGaps();

        analyzer.SaveToFile("primes.txt");

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
