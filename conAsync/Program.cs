using System;
using System.Threading;
using System.Threading.Tasks;

namespace conAsync
{
    class Program
    {
        static async Task Main(string[] args)
        {
            DateTime dtStart = DateTime.Now;

            var task1 = PerformTaskAsync(1);
            var task2 = PerformTaskAsync(2);
            var task3 = PerformTaskAsync(3);
            var task4 = PerformTaskAsync(4);
            var task5 = PerformTaskAsync(5);

            await Task.WhenAll(task1, task2);

            var task6 = PerformTaskAsync(6);

            Console.WriteLine($"{DateTime.Now:HH:mm:ss} : Total Time: Processing {task1.Result + task2.Result + task3.Result + task4.Result + task5.Result + task6.Result } : Runtime {(DateTime.Now - dtStart).TotalSeconds}");
        }

        static int PerformTask(int i)
        {
            Console.WriteLine($"{DateTime.Now:HH:mm:ss} : Performing Task For {i}s");
            Thread.Sleep(i * 1000);
            return i;
        }

        static async Task<int> PerformTaskAsync(int i)
        {
            Console.WriteLine($"{DateTime.Now:HH:mm:ss} : Performing Task For {i}s");
            await Task.Delay(i * 1000);
            Console.WriteLine($"{DateTime.Now:HH:mm:ss} : Completing Task {i}");
            return i;
        }
    }
}
