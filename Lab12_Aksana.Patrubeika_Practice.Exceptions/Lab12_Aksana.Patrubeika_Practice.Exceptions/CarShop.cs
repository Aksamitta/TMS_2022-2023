using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12_Aksana.Patrubeika_Practice.Exceptions
{
    public class CarShop
    {
        public List<Car> carList = new List<Car>();  //агрегация        

        public void AddCar(Car cars)
        {
            try
            {
                if (carList.Count >= 2)
                {
                    throw new Exception("Exception: A lot of cars in list");
                }
                else
                {
                    carList.Add(cars);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }


        public string RemoveCar(string brandName)
        {
            var car = carList.FirstOrDefault(x => x.Brand == brandName);            
            try
            {
                if (car == null)
                {
                    throw new Exception("Exception: the car doen't include in shop!");
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
            //var car = carList.FirstOrDefault(x => x.Brand == brandName);
            //carList.Remove(car);
            //return "Succesfully remoived";
        }

        public string DiscountCar(string brandName)
        {
            var car = carList.FirstOrDefault(x => x.Brand == brandName);
            try
            {
                if (car == null)
                {
                    throw new Exception("Exception: the car doen't include in shop!");
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

        public string ShowCar()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Car car in carList)
            {
                sb.AppendLine($"Brand: {car.Brand}, Price: {car.Price}, Engine: {car.Engine} ");
            }
            //Console.WriteLine( sb.ToString() );
            return sb.ToString();
        }

        //we should add a delagate
        //public delegate void ShopHandler(string mes);
        public delegate void ShopEmpty();
        public delegate void ShopFully();

        public void CarsInShop()
        {
            Console.WriteLine("CarShop is empty.");
        }

        //we should add an event
        //public event ShopEmpty CarAmount;
        //public event ShopFully CarAmountFull;

        //public void TakeCars()
        //{
        //    if (carList.Count() == 0)
        //    {
        //        CarAmount?.Invoke();
        //    }
        //    else
        //    {
        //        CarAmountFull?.Invoke();
        //    }

        //}
    }
}
