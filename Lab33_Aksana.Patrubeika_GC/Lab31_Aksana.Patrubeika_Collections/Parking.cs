using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Lab31_Aksana.Patrubeika_Collections
{
    internal class Parking : IEnumerable
    {
        //нету доступа к списку
        private List<Car> _cars = new List<Car>();
        private const int MAX_CARS = 100;

        //модификатор для доступа к прайват полям класса, т.е. через индексаторы - запросы к колекциям
        public Car this[string number]
        {
            get
            {
                var car = _cars.FirstOrDefault(c => c.Number == number);
                return car;
            }
        }

        //только для чтения, доступ к закрытому полю класса на чтение
        public int Count => _cars.Count;
        public string Name { get; set; }

        public int Add(Car car)
        {
            if (car == null)
            {
                throw new ArgumentException(nameof(car), "Car is not");
            }

            if (_cars.Count < MAX_CARS)
            {
                _cars.Add(car);
                return _cars.Count - 1;
            }
            return -1;
        }


        public IEnumerator GetEnumerator()
        {
            var sum = 0;
            for (int i = 0; i < _cars.Count; i++)
            {
                sum = i + (i + 1);
                yield return $"for {i}: {sum}";
            }
        }

        //public IEnumerator GetEnumerator()
        //{
        //    foreach (var car in _cars)
        //    {
        //        yield return car;
        //    }
        //}

        //public IEnumerable GetSumElements()
        //{
        //    var sum = 0;
        //    for (int i = 0; i < _cars.Count; i++)
        //    {
        //        sum = i + (i + 1);
        //        yield return $"for {i}: {sum}";
        //    }            
        //}

        public IEnumerable GetNames()
        {
            foreach (var car in _cars)
            {
                yield return $"{car.Model} {car.Number}";
            }

            //}

            //public IEnumerator<Car> GetEnumerator()
            //{
            //    return _cars.GetEnumerator();
            //}

            //IEnumerator IEnumerable.GetEnumerator()
            //{
            //    return _cars.GetEnumerator();
            //}
        }       

    }
    
}
