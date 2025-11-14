static void Main()
{
    Console.Write("Enter the upper limit: ");
    if (!int.TryParse(Console.ReadLine(), out int limit) || limit < 2)
    {
        Console.WriteLine("Invalid input. Please enter a number >= 2.");
        return;
    }

    List<int> primes = GeneratePrimes(limit);
    File.WriteAllLines("primes.txt", primes.ConvertAll(p => p.ToString()));

    Console.WriteLine($"Generated {primes.Count} primes up to {limit} and saved to primes.txt");

    Console.WriteLine("First 10 primes:");
    for (int i = 0; i < Math.Min(10, primes.Count); i++)
    {
        Console.Write(primes[i] + " ");
    }
    Console.WriteLine("...");

    List<int> gaps = new List<int>();
    for (int i = 1; i < primes.Count; i++)
    {
        gaps.Add(primes[i] - primes[i - 1]);
    }

    if (gaps.Count > 0)
    {
        int maxGap = 0;
        int sumGap = 0;
        foreach (var g in gaps)
        {
            if (g > maxGap) maxGap = g;
            sumGap += g;
        }
        double avgGap = (double)sumGap / gaps.Count;
        Console.WriteLine($"\nPrime gaps analysis:");
        Console.WriteLine($"Largest gap: {maxGap}");
        Console.WriteLine($"Average gap: {avgGap:F2}");
    }
}
