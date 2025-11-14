using System;
using System.IO;
using System.Collections.Generic;

public class PrimeAnalyzer
{
    public int Limit { get; private set; }
    public List<int> Primes { get; private set; }

    public PrimeAnalyzer(int limit)
    {
        Limit = limit;
        Primes = new List<int>();
    }

    public void GeneratePrimes()
    {
        for (int num = 2; num <= Limit; num++)
        {
            if (IsPrime(num))
                Primes.Add(num);
        }
    }

    private bool IsPrime(int n)
    {
        if (n < 2) return false;
        for (int i = 2; i * i <= n; i++)
            if (n % i == 0) return false;
        return true;
    }

    public void PrintFirstPrimes(int count)
    {
        Console.WriteLine($"First {count} primes:");
        for (int i = 0; i < Math.Min(count, Primes.Count); i++)
            Console.Write(Primes[i] + " ");
        Console.WriteLine("...");
    }

    public void AnalyzeGaps()
    {
        if (Primes.Count < 2)
        {
            Console.WriteLine("Not enough primes to analyze gaps.");
            return;
        }

        int[] gaps = new int[Primes.Count - 1];
        int sum = 0, maxGap = 0;

        for (int i = 1; i < Primes.Count; i++)
        {
            gaps[i - 1] = Primes[i] - Primes[i - 1];
            sum += gaps[i - 1];
            if (gaps[i - 1] > maxGap) maxGap = gaps[i - 1];
        }

        double avgGap = (double)sum / gaps.Length;
        Console.WriteLine($"\nPrime gaps analysis:");
        Console.WriteLine($"Largest gap: {maxGap}");
        Console.WriteLine($"Average gap: {avgGap:F2}");
    }

    public void SaveToFile(string filename)
    {
        File.WriteAllLines(filename, Primes.ConvertAll(p => p.ToString()));
        Console.WriteLine($"Primes saved to {filename}");
    }
}
