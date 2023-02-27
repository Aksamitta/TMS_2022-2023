using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10_Aksana.Patrubeika_Delegates
{    
    public class CarShop
    {
        public List<Car> carList = new List<Car>();  //агрегация        
        public delegate string EmptyCarShop();    //создаем делегат
        public event EmptyCarShop Empty;    //создаем событие под наш делегат
        public event Action NoCar;   //создаем событие под наш делегат
        public event Action NotEnoughtCar;


        public void AddCar(Car cars)
        {
            try
            {
                if (carList.Count >= 2)
                {
                    throw new Exception("A lot of cars in list!!");
                }
                else
                {
                    carList.Add(cars);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}\n");
            }
        }

        public string RemoveCar(string brandName)
        {
            var car = carList.FirstOrDefault(x => x.Brand == brandName);
            if (carList.Count == 0)
            {
                return Empty.Invoke();
            }
            else
            {                
                try
                {
                    if (car == null)
                    {
                        throw new Exception("the car doesn't include in shop!");
                    }
                    else
                    {
                        carList.Remove(car);
                        return "Excelent!";
                    }
                }
                catch (Exception ex)
                {
                    return $"Exception: {ex.Message}";
                }
            }            
        }

        public string DiscountCar(string brandName)
        {
            if (carList.Count == 0)
            {
                return Empty.Invoke();
            }
            else
            {
                var car = carList.FirstOrDefault(x => x.Brand == brandName);
                try
                {
                    if (car == null)
                    {
                        throw new Exception("the car doen't include in shop!");
                    }
                    else
                    {
                        return car.GetDiscount();
                    }
                }
                catch (Exception ex)
                {
                    return $"Exception: {ex.Message}";
                }
            }
        }

        public string ShowCar()
        {
            if (carList.Count == 0)
            {
                return Empty.Invoke();
            }
            else
            {
                StringBuilder sb = new StringBuilder();

                foreach (Car car in carList)
                {
                    sb.AppendLine($"Brand: {car.Brand}\t Price: {car.Price}\t Engine: {car.Engine} ");
                }
                return sb.ToString();
            }            
        }
        
        public void Message()
        {
            if (carList.Count != 0) NoCar();
        }

        public void Message2()
        {
            if (carList.Count == 1) NotEnoughtCar();
        }

    }
}
