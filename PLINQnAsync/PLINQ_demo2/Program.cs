using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    private static bool IsPrime(int number)
    {
        bool result = true;
        if (number < 2)
        {
            return false;
        }
        for (var divisor = 2; divisor <= Math.Sqrt(number) && result == true; divisor++)
        {
            if (number % divisor == 0)
            {
                result = false;
            }
        }
        return result;
    }
    private static IList<int> GetPrimeList(IList<int> numbers) => numbers.Where(IsPrime).ToList();
    private static IList<int> GetPrimeListWithParallel(IList<int> numbers)
    {
        var primeNumbers = new ConcurrentBag<int>();
        Parallel.ForEach(numbers, number =>
        {
            if (IsPrime(number))
            {
                primeNumbers.Add(number);
            }
        });
        return primeNumbers.ToList();
    }
    static void Main()
    {
        var limit = 1_500_000;
        var numbers = Enumerable.Range(0, limit).ToList();

        var watch = Stopwatch.StartNew();
        var primeNumbersFromForeach = GetPrimeList(numbers);
        watch.Stop();

        var watchForParallel = Stopwatch.StartNew();
        var primeNumbersFromParallelForeach = GetPrimeListWithParallel(numbers);
        watchForParallel.Stop();

        Console.WriteLine($"Classical foreach loop | Total prime numbers :" +
        $" {primeNumbersFromForeach.Count} | Time Taken : " +
        $"{watch.ElapsedMilliseconds} ms.");

        Console.WriteLine($"Parallel.ForEach loop | Total prime numbers :)" + $"{primeNumbersFromParallelForeach.Count} | Time Taken : " + $"{watchForParallel.ElapsedMilliseconds} ms");
        Console.WriteLine("Press any key to exit.");
        Console.ReadLine(); 
    }
}