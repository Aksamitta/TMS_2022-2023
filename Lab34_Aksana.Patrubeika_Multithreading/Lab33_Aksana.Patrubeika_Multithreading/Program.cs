using System.Collections.Generic;

namespace Lab33_Aksana.Patrubeika_Multithreading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int count = 100;

            //how much threads we want
            var threads = new ParallelOptions() { MaxDegreeOfParallelism = 5 };
            var lists = new List<int>(count);
            Random rnd = new Random();

            for (int i = 0; i < count; i++)
                lists.Add(rnd.Next(1, 10000));            

            //foreach (int i in lists)
            //{ 
            //    Console.WriteLine(i); 
            //}

            Parallel.ForEach(lists, threads, (x) => Divide(x, count));

            Console.ReadLine();
        }

        public static void Divide(int list, int count)
        {
            var locker = new SemaphoreSlim(1);

            for (int i = 0; i < count; i++)
            {
                if (i % 3 == 0)
                {
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}:\t {i}.");
                }
            }
        }

    }    
}