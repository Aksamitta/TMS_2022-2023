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
            //который принимает в себя объекты и при перечислении выдает сумму со следующим элементом
            #endregion


            //var book = new BookCollection();
            ////book.Add("book1");
            //for (int i = 0; i < 5; i++)
            //{
            //    book.Add(Console.ReadLine());
            //}

            //foreach (int n in book)
            //{
            //    Console.WriteLine(n);
            //}

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

            //interfase methods
            Console.WriteLine("Cars at parking:");
            foreach (var car in parking)
            {
                Console.WriteLine($"{car};");
            }

            Console.WriteLine();

            Console.WriteLine("Car's model");
            foreach (var name in parking.GetNames())
            {
                Console.Write($"{name}, ");
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Sum:");
            foreach (var car in parking.GetSumElements())
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

        interface IBookCollection : IEnumerable<string>
        {
            void Add(string book);

            IEnumerable<string> GetElements();
        }

         

        public class BookCollection : IBookCollection
        {
            private string[] _internalArray;
            private int _currentIndex;

            public BookCollection(int size)
            {
                _internalArray = new string[size];
            }

            public BookCollection()
            {
                _internalArray = new string[10];
                _currentIndex = 0;
            }


            public void Add(string book)
            {
                if (_currentIndex != _internalArray.Length)
                {
                    _internalArray[_currentIndex++] = book;
                }
                else
                {
                    var tmpArray = new string[_internalArray.Length * 2];
                    Array.Copy(_internalArray, tmpArray, 10);
                    _internalArray = tmpArray;
                    _internalArray[_currentIndex++] = book;
                }
            }

            public IEnumerator<int> GetEnumerator()
            {
                int sum = 0;
                for (int i = 0; i < _internalArray.Length; i++)
                {
                    sum += i;
                }
                yield return sum;
            }



            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }


            public IEnumerable<string> GetElements()
            {
                throw new NotImplementedException();
            }

            IEnumerator<string> IEnumerable<string>.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
    }
}