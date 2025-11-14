using System;
using System.IO;
using System.Collections.Generic;

class Program
{
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
}

    static List<int> GeneratePrimes(int limit)
    {
        List<int> primes = new List<int>();
        for (int num = 2; num <= limit; num++)
        {
            if (IsPrime(num))
                primes.Add(num);
        }
        return primes;
    }

    static bool IsPrime(int n)
    {
        if (n < 2) return false;
        for (int i = 2; i * i <= n; i++)
            if (n % i == 0)
                return false;
        return true;
    }
}
