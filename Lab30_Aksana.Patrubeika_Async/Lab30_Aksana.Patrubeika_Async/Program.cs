using System.Runtime.CompilerServices;

namespace Lab30_Aksana.Patrubeika_Async
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            #region async/await
            //Console.WriteLine("Begin main");            
            //DoWorkAsync();
            //Console.WriteLine("Continue main");

            //int j = 0;
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine("Main");
            //}
            //Console.WriteLine("End main");
            //Console.ReadLine();
            #endregion

            #region our Lesson
            //var cTs = new CancellationTokenSource();
            //var task1 = PrintAsync(50, cTs.Token);
            //var task2 = PrintAsync(50, cTs.Token);

            //Console.WriteLine("Some other instructions...");

            //Thread.Sleep(1000);
            //cTs.Cancel();

            //var res = await Task.WhenAll(task1, task2);

            //Console.WriteLine($"Task: {res[0]}");
            //Console.WriteLine($"Task: {res[1]}");

            #endregion

            List<string> cities = new List<string> { "Moscow", "Paris", "Minsk", "Berlin", "Warsaw", "Riga"};
            
            var clcToken = new CancellationTokenSource();
            var token = clcToken.Token;

            var task = new Task(() => TaskAsync(cities, clcToken.Token), token);
            task.Start();

            Thread.Sleep(1000);
            clcToken.Cancel();
            Thread.Sleep(1000);
            Console.WriteLine($"Task Status: {task.Status}");
            clcToken.Dispose();

        }

        static async Task DoWorkAsync()
        {
            Console.WriteLine("Begin Async");
            await Task.Run(() => DoWork());
            Console.WriteLine("End Async");
        }

        static void DoWork()
        {
            int j = 0;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("DoWork");
            }
        }

        static async Task<int> PrintAsync(int delay, CancellationToken token)
        {
            await Task.Delay(delay);
            int i = 0;
            while (true)
            {
                i++;
                if(token.IsCancellationRequested)
                {
                    break;
                }                
            }
            return i;
        }

        static async Task TaskAsync(List<string> list, CancellationToken token)
        {
            for (int i = 1; i <= list.Count; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("code: 299");
                    return;
                }
                Console.WriteLine(list[i]);
                Thread.Sleep(200);
            }
        }
    }
}