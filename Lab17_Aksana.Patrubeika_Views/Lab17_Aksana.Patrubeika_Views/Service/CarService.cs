using Lab17_Aksana.Patrubeika_Views.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Numerics;

namespace Lab17_Aksana.Patrubeika_Views.Service

{
    public class CarService
    {
        public readonly List<Car> carList = new List<Car>();

        public void AddCar(Car car)
        {
            car.Id = FindFirstFreeId();
            carList.Add(car);
        }

        public List<Car> ShowCars()
        {
            return carList;
        }

        private int FindFirstFreeId()
        {
            var orderedId = from car in carList
                            orderby car.Id
                            select car.Id;
            var result = Enumerable.Range(1, int.MaxValue).Except(orderedId).First();
            return result;
        }
    }
}
