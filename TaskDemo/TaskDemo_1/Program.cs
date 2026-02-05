using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void PrintNumber(string message)
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"{message}:{i}");
            Thread.Sleep(1000);
        }
    }
    static void Main()
    {
        Thread.CurrentThread.Name = "Main";
        Task task01 = new Task(() => PrintNumber("Task 01"));
        task01.Start();
        Task task02 = Task.Run(delegate {
            PrintNumber("Task 02");
        });
        Task task03 = new Task(new Action(() => {
            PrintNumber("Task 03");
        }));
        task03.Start();
        Console.WriteLine($"Thread '{Thread.CurrentThread.Name}'");
        Console.ReadKey();
    }
}