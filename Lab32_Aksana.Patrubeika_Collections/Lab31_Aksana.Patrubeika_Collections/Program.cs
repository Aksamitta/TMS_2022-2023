using System.Collections;
using System.Net.Http.Headers;

namespace Lab31_Aksana.Patrubeika_Collections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task
            //Создать собственную коллекцию реализующий IEnumerable интерфейс,
            //который принимает в себя объекты и при перечислении выдает сумму
            //со следующим элементом
            #endregion
           

            var cars = new List<Car>()
            {
                new Car() { Model = "Tesla", Number = "A0236DF"},
                new Car() { Model = "Audi", Number = "C1256DG"},
                new Car() { Model = "Audi", Number = "S02455DF"},
                new Car() { Model = "BMW", Number = "E02455DF"},
                new Car() { Model = "BMW", Number = "S01455DT"},
                new Car() { Model = "Audi", Number = "S058455DF"},
                new Car() { Model = "BMW", Number = "S02455PF"}
            };
            var parking = new Parking();

            //Add cars
            foreach (var car in cars)
            {
                parking.Add(car);
            }

            ////interfase methods using GetEnumerator
            //Console.WriteLine("Cars at parking:");
            //foreach (var car in parking)
            //{
            //    Console.WriteLine($"{car};");
            //}

            Console.WriteLine();

            //show names using method Enumerable GetName
            Console.WriteLine("Car's model");
            foreach (var name in parking.GetNames())
            {
                Console.WriteLine($"{name}, ");
            }

            Console.WriteLine();
            Console.WriteLine();

            //Console.WriteLine("Using IEnumerable.");
            //Console.WriteLine("Sum:");
            //foreach (var car in parking.GetSumElements())
            //{
            //    Console.WriteLine(car);
            //}

            Console.WriteLine("Using IEnumerator.");
            Console.WriteLine("Sum:");
            foreach (var car in parking)
            {
                Console.WriteLine(car);
            }

            //обращаемся к паркингу по индексу через модификатор
            //Console.WriteLine(parking["A0236DF"]?.Model);
            //Console.WriteLine(parking["A0237DF"]?.Model);


            //foreach (var item in parking)
            //{
            //    Console.Write(item + " ");
            //}

            Console.ReadLine();
        }

       
    }
}